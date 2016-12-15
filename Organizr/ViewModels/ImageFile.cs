using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

namespace Organizr.ViewModels
{
    class ImageFile
    {
        private string _path;
        private BitmapFrame _imageCache;
        private DateTime _dateTaken = DateTime.MinValue;
        public ImageFile(string file)
        {
            _path = file;
        }

        public DateTime DateTaken
        {
            get
            {
                return _dateTaken == DateTime.MinValue ? TryGetMetaDataDate() : _dateTaken;
            }
            set
            {
                _dateTaken = value;
            }
        }

        public BitmapFrame Bitmap
        {
            get
            {
                return _imageCache ?? (_imageCache = BitmapFrame.Create(new Uri(_path, UriKind.Absolute)));
            }
        }

        public override string ToString()
        {
            return _path;
        }

        public void Save(string mes)
        {
            var bmp = new Bitmap(_path);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                using (Font arialFont = new Font("Arial", bmp.Height/25, GraphicsUnit.Pixel))
                {
                    var bb = graphics.MeasureString(mes, arialFont);
                    graphics.DrawString(DateTaken.ToString("yyyy-MM-dd"), arialFont, Brushes.Lime, 0, bmp.Height - bb.Height);
                    graphics.DrawString(mes, arialFont, Brushes.Lime, bmp.Width - bb.Width, bmp.Height - bb.Height);
                }
            }
            bmp.Save(Path.GetFileName(_path));
        }

        private DateTime TryGetMetaDataDate()
        {
            try
            {
                return Convert.ToDateTime(((BitmapMetadata)Bitmap.Metadata).DateTaken);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

    }
}
