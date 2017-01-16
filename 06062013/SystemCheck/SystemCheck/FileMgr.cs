using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace SystemCheck
{
    public class FileMgr
    {
        SystemCheck.Strings _strings = new SystemCheck.Strings();

        HybridDictionary hyd = new HybridDictionary();
        //string appPath = _strings.appPath2;

        public HybridDictionary GetSqlScriptFileName(Strings.enumCategory Category)
        {
            hyd.Clear();

            //Get all scripts in main path first
            DirectoryInfo di = new DirectoryInfo(_strings.CodePath);
            foreach ( FileInfo fi in di.GetFiles("*.sql", SearchOption.AllDirectories) )
            {
                hyd.Add(fi.FullName, fi.Name);
            }

            switch (Category)
            {
                case Strings.enumCategory.Configuration:
                    break;

                case Strings.enumCategory.Operation:
                    break;

                case Strings.enumCategory.Performance:
                    break;

                case Strings.enumCategory.All:
                    break;

            }
            return hyd;
        }

        
        public string GetCodeFileContents(FileInfo fi)
        {
            return System.IO.File.ReadAllText(fi.FullName);
        }

        /// <summary>
        /// Return the name of a file under the install path. This is useful for returning the dtChecklist.xml file, 
        /// or any other, without having to know the path. It will aid the installation by not 
        /// requiring a different path for debug and release configurations. 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public FileInfo GetFile(string strFileName)
        {
            
            string[] strFullPath;
            strFullPath = Directory.GetFiles(_strings.CodePath, strFileName, SearchOption.AllDirectories);
            FileInfo fi = new FileInfo(strFullPath[0]);
            return fi;
        }

        /// <summary>
        /// Returns a standard save file dialog 
        /// </summary>
        /// <param name="fileName">What is the name of the file you want?</param>
        /// <param name="blnIsAddUniqueFileName">Would you like to add some type of uniqueifier to the name?</param>
        /// <param name="filter">A filter to be added to the save dialog. An example would be "XML Files|*xml"</param>
        /// <param name="defaultExtension">What is the extension you'd like to default?</param>
        /// <param name="IsCheckIfFileExists">Should I check if the file already exists?</param>
        /// <param name="IsCheckIfPathExists">Should I check to ensure the path exists?</param>
        /// <param name="IsAddExtension">Should I add the extension if it does not exist?</param>
        /// <param name="IsSupportMultiDotExtension">Should I allow a multi-dotted extension?</param>
        /// <returns></returns>
        public SaveFileDialog SaveFile(
            string fileName,
            Boolean blnIsAddUniqueFileName,
            string filter,
            string defaultExtension,
            Boolean IsCheckIfFileExists,
            Boolean IsCheckIfPathExists,
            Boolean IsAddExtension,
            Boolean IsSupportMultiDotExtension)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            StringBuilder sbFileName = new StringBuilder();
            dlg.Filter = filter;
            dlg.DefaultExt = defaultExtension;
            dlg.CheckFileExists = IsCheckIfFileExists;
            dlg.CheckPathExists = IsCheckIfPathExists;
            dlg.AddExtension = IsAddExtension;
            dlg.SupportMultiDottedExtensions = IsSupportMultiDotExtension;

            sbFileName.Append(fileName);
            if (blnIsAddUniqueFileName == true)
            {
                sbFileName.Append("_");
                sbFileName.Append(DateTime.Now.Month);
                sbFileName.Append("_");
                sbFileName.Append(DateTime.Now.Day);
                sbFileName.Append("_");
                sbFileName.Append(DateTime.Now.Year);
                sbFileName.Append("_");
                sbFileName.Append(DateTime.Now.Millisecond);
            }

            dlg.FileName = sbFileName.ToString();

            return dlg;

        }

        /// <summary>
        /// Returns a standard open file dialog
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        /// <param name="filter">The filter of files to open</param>
        /// <param name="defaultExtension">The default file extension to open</param>
        /// <param name="IsCheckIfFileExists">Should I throw a warning if the user tries to load a file that doesn't exist?</param>
        /// <param name="IsCheckIfPathExists">Should I throw a warning if the user tries to load from a path that doesn't exist?</param>
        /// <param name="IsAddExtension">Should I default the extension if the user forgets to?</param>
        /// <param name="IsSupportMultiDotExtension">Should I support a multi-dotted extension?</param>
        /// <returns></returns>
        public OpenFileDialog OpenFile(
            string fileName,
            string filter,
            string defaultExtension,
            Boolean IsCheckIfFileExists,
            Boolean IsCheckIfPathExists,
            Boolean IsAddExtension,
            Boolean IsSupportMultiDotExtension)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = IsAddExtension;
            ofd.CheckPathExists = IsCheckIfPathExists;
            ofd.DefaultExt = defaultExtension;
            ofd.FileName = fileName;
            ofd.Filter = filter;
            ofd.Multiselect = false;
            
            return ofd;
        }


        /// <summary>
        /// Given a file name with potentially illegal characters, 
        /// this routine will remove those characters and return a legal windows file name
        /// </summary>
        /// <param name="fileName">The file name to check</param>
        /// <returns></returns>
        public string StripIllegalCharactersFromFileName(string fileName)
        {
            //Known illegal characters
            //MSDN Documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx
            // <
            // >
            // :
            // "
            // /
            // \
            // |
            // ?
            // *

            string fixedFileName = fileName;

            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            fixedFileName = r.Replace(fileName, string.Empty);
            return fixedFileName;
        }
    }
}
