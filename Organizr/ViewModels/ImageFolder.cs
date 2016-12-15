using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Organizr.ViewModels
{
    class ImageFolder
    {
        private string _path;
        private HashSet<string> _extensions = new HashSet<string> { "jpg", "jpeg", "png", "bmp" }; 
        public ImageFolder()
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            _path = dialog.SelectedPath;
        }

        public IEnumerable<ImageFile> Contents
        {
            get
            {
                return Directory.EnumerateFiles(_path,"*", SearchOption.AllDirectories).Where(f => _extensions.Any(ex => f.ToLower().EndsWith(ex))).Select(f => new ImageFile(f));
            }
        }
    }
}
