using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    class FileModel
    {
        public FileModel()
        {
            _files = new List<File>();
        }

        private List<File> _files;

        public void AddFile(File file)
        {
            if (!_files.Contains(file))
            {
                _files.Add(file);
            }
        }

        public void RemoveFile(File file)
        {
            if(!_files.Contains(file))
            {
                _files.Remove(file);
            }
        }

        public List<File> GetFiles()
        {
            return _files;
        }
    }



}
