using System;
using System.IO;
using EnvDTE;
using EnvDTE80;
using EventDayDsl.EventDay;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace EventDayDsl
{
    public class RunningDocTableEvents : IVsRunningDocTableEvents
    {
        private readonly GenerateDslCodePackage _package;
        private readonly ProjectItemsEvents _projectItemsEvents;

        public RunningDocTableEvents(GenerateDslCodePackage package)
        {
            _package = package;
            _projectItemsEvents = ((Events2) _package.Dte.Events).ProjectItemsEvents;
            _projectItemsEvents.ItemRemoved += LogRemovedFile;
            _projectItemsEvents.ItemRenamed += OnItemRenamed;
        }

        private IDisposable StopListeningToItemRemovedEvent()
        {
            _projectItemsEvents.ItemRemoved -= LogRemovedFile;
            return new DisposableAction(()=> _projectItemsEvents.ItemRemoved += LogRemovedFile);
        }

        public int OnAfterFirstDocumentLock(uint docCookie, uint dwRdtLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
        {
            return VSConstants.S_OK;
        }

        public int OnBeforeLastDocumentUnlock(uint docCookie, uint dwRdtLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
        {
            return VSConstants.S_OK;
        }

        private void LogRemovedFile(ProjectItem item)
        {
            var fileName = item.FileNames[0];
            if (Path.GetExtension(fileName) == ".dsl")
                _package.OutputPane.OutputString($"Delete {Path.GetFileName(fileName)}{Environment.NewLine}");
        }

        private void OnItemRenamed(ProjectItem item, string oldname)
        {
            var fileName = item.FileNames[0];
            if (Path.GetExtension(fileName) == ".dsl")
            {
                GenerateCode(fileName, item);
            }
        }

        public int OnAfterSave(uint docCookie)
        {
            var document = _package.GetDocument(docCookie);
            if (document == null)
                return VSConstants.S_OK;

            var fullName = document.FullName;

            if (Path.GetExtension(fullName) != ".dsl")
                return VSConstants.S_OK;

            var item = document.ProjectItem;

            GenerateCode(fullName, item);
            return VSConstants.S_OK;
        }

        private void GenerateCode(string fullName, ProjectItem projectItem)
        {
            try
            {
                var fileName = Path.GetFileName(fullName);

                _package.OutputPane.OutputString($"Generating {fileName}...{Environment.NewLine}");

                //Remove old files
                using (StopListeningToItemRemovedEvent())
                {
                    foreach (ProjectItem item in projectItem.ProjectItems)
                    {
                        item.Delete();
                    }
                }

                //Generate new files.
                foreach (var file in Generator.GenerateFile(fullName))
                {
                    projectItem.ProjectItems.AddFromFile(file);
                }
                projectItem.ContainingProject.Save();
            }
            catch (Exception e)
            {
                _package.OutputPane.OutputString($"{e}{Environment.NewLine}");
                _package.OutputPane.Activate();
            }
        }

        public int OnAfterAttributeChange(uint docCookie, uint grfAttribs)
        {
            return VSConstants.S_OK;
        }

        public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame)
        {
            return VSConstants.S_OK;
        }

        public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame)
        {
            return VSConstants.S_OK;
        }
    }
}