﻿using System;
using SmartStore.Core.Infrastructure.DependencyManagement;
using SmartStore.Core.IO;
using SmartStore.Core.Logging;
using SmartStore.Utilities;

namespace SmartStore.Core
{
	public class ApplicationEnvironment : IApplicationEnvironment
	{
		public ApplicationEnvironment(IVirtualPathProvider vpp, Work<ILogger> logger)
		{
			WebRootFolder = new VirtualFolder("~/", vpp, logger);
			AppDataFolder = new VirtualFolder("~/App_Data/", vpp, logger);
			ThemesFolder = new VirtualFolder(CommonHelper.GetAppSetting<string>("sm:ThemesBasePath", "~/Themes/"), vpp, logger);
			PluginsFolder = new VirtualFolder("~/Plugins/", vpp, logger);
		}

		public virtual string EnvironmentIdentifier
		{
			get
			{
				// use the current host and the process id as two servers could run on the same machine
				return Environment.MachineName + "-" + System.Diagnostics.Process.GetCurrentProcess().Id;
			}
		}

		public virtual IVirtualFolder WebRootFolder { get; private set; }
		public virtual IVirtualFolder AppDataFolder { get; private set; }
		public virtual IVirtualFolder ThemesFolder { get; private set; }
		public virtual IVirtualFolder PluginsFolder { get; private set; }
	}
}
