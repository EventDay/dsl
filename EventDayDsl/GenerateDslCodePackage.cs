// Copyright (C) 2015 EventDay, Inc

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using IServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace EventDayDsl
{
    /// <summary>
    ///     This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The minimum requirement for a class to be considered a valid package for Visual Studio
    ///         is to implement the IVsPackage interface and register itself with the shell.
    ///         This package uses the helper classes defined inside the Managed Package Framework (MPF)
    ///         to do it: it derives from the Package class that provides the implementation of the
    ///         IVsPackage interface and uses the registration attributes defined in the framework to
    ///         register itself and its components with the shell. These attributes tell the pkgdef creation
    ///         utility what data to put into .pkgdef file.
    ///     </para>
    ///     <para>
    ///         To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...
    ///         &gt; in .vsixmanifest file.
    ///     </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
        Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideAutoLoad(UIContextGuids80.NoSolution)]
    public sealed class GenerateDslCodePackage : Package
    {
        /// <summary>
        ///     GenerateDslCodePackage GUID string.
        /// </summary>
        public const string PackageGuidString = "782a8f26-cf8b-4b24-81ef-ad226a5816d3";

        private readonly Lazy<RunningDocumentTable> _documentTable;
        private readonly Lazy<DTE2> _dte;
        private readonly Lazy<IVsOutputWindowPane> _outputWindow;

        public GenerateDslCodePackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.

            _outputWindow = new Lazy<IVsOutputWindowPane>(() =>
            {
                var window = (IVsOutputWindow) GetGlobalService(typeof (SVsOutputWindow));
                var paneId = new Guid("f85a97a090524a6c8b42247a33276024");
                window.CreatePane(ref paneId, "EventDay DSL", 1, 1);

                IVsOutputWindowPane pane;
                window.GetPane(ref paneId, out pane);
                return pane;
            });
            _dte = new Lazy<DTE2>(() => ServiceProvider.GlobalProvider.GetService(typeof (DTE)) as DTE2);
            var sp = new Lazy<IServiceProvider>(() => GetGlobalService(typeof (IServiceProvider)) as IServiceProvider);
            _documentTable =
                new Lazy<RunningDocumentTable>(() => new RunningDocumentTable(new ServiceProvider(sp.Value)));
        }

        public IVsOutputWindowPane OutputPane => _outputWindow.Value;

        public DTE2 Dte => _dte.Value;

        #region Package Members

        /// <summary>
        ///     Initialization of the package; this method is called right after the package is sited, so this is the place
        ///     where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            _documentTable.Value.Advise(new RunningDocTableEvents(this));
        }

        #endregion

        public Document GetDocument(uint docCookie)
        {
            var info = _documentTable.Value.GetDocumentInfo(docCookie);
            return _dte.Value.Documents.OfType<Document>().SingleOrDefault(x => x.FullName == info.Moniker);
        }
    }
}