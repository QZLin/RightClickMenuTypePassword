using System;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePass.Util;
using KeePassLib;

namespace AutoTypeSingle
{
    public sealed class AutoTypeSingleExt : Plugin
    {
        private IPluginHost pluginHost = null;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null) return false;
            pluginHost = host;
            return true;
        }
        public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
        {
            // Provide a menu item for the main location(s)
            if (t == PluginMenuType.Entry)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem { Text = "AutoType Password" };
                tsmi.Click += OnEntryAutoTypePasswordClick;
                return tsmi;
            }

            return null; // No menu items in other locations
        }

        /*private void OnOptionsClicked(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            var parent = item.OwnerItem;
        }*/
        private void OnEntryAutoTypeNameClick(object sender, EventArgs e)
        {
            if (pluginHost.MainWindow.GetSelectedEntriesCount() == 1)
            {
                PwEntry pe = pluginHost.MainWindow.GetSelectedEntry(false);
                AutoType.PerformIntoPreviousWindow(Form.ActiveForm, pe, pluginHost.Database, "{USERNAME}");
            }
        }
        private void OnEntryAutoTypePasswordClick(object sender, EventArgs e)
        {
            if (pluginHost.MainWindow.GetSelectedEntriesCount() == 1)
            {
                PwEntry pe = pluginHost.MainWindow.GetSelectedEntry(false);
                AutoType.PerformIntoPreviousWindow(Form.ActiveForm, pe, pluginHost.Database, "{PASSWORD}");
            }
        }
    }
}