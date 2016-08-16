using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BestCS.Compression.SevenZip;
using System.IO;
using System.Threading;

namespace DSharpIDE
{
   
    public partial class Configurator : Form
    {
        String[] lines;
        static string DINRUS;
        static string file;
        bool confWorking = false;
        public Cursor Cursor { get; set; }


        enum SC : int
        {
            NONE = 0,
            DCA = 1,
            R1CA = 2,
            R2CA = 3,
            DCF = 4,
            R1CF = 5,
            R2CF = 6,
            DWA = 7,
            R1WA = 8,
            R2WA = 9,
            DWF = 10,
            R1WF = 11,
            R2WF = 12
        };
        
        private SC cf;  
        

         public Configurator()
        {
            InitializeComponent();

            DINRUS = System.Environment.GetEnvironmentVariable("DINRUS");
            file = DINRUS + "\\SC.INI";
            lines = System.IO.File.ReadAllLines(file);
            scIniText.Lines = lines;
        }

         private void configChanged()
         {
             newCfgText.Text = versionCombo.Text +" "+modeLabel.Text +" "+ versionParamLabel.Text;
             newCfgLabel.Visible = true;
             newCfgText.Visible = true;
         }

        private void scIniTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!confWorking)
            {
                saveScIni.Enabled = true;
                saveScIni.Visible = true;
            }
        }

        private void configuratorClosed(object sender, FormClosedEventArgs e)
        {
           // MainForm.configShown = false;
        }

        private void versionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            versionLabel.Text = versionCombo.Text;
            configChanged();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            versionParamLabel.Text = "ПОЛНАЯ";
            configChanged();
        }

        private void consoleRadio_CheckedChanged(object sender, EventArgs e)
        {
            modeLabel.Text = "КОНСОЛЬ";
            configChanged();
        }

        private void windowRadio_CheckedChanged(object sender, EventArgs e)
        {
            modeLabel.Text = "ОКНО";
            configChanged();
        }

        private void versionRadio_CheckedChanged(object sender, EventArgs e)
        {
            versionParamLabel.Text = "ОДИНОЧНАЯ";
            configChanged();
        }

        private void Configurator_FormClosing(object sender, FormClosingEventArgs e)
        {
            PowerfulEditor.confOpened = false;
        }

        private void newCfgText_TextChanged(object sender, EventArgs e)
        {
            updateConf.Visible = true;
            updateConf.Enabled = true;
            newCfgLabel.Text = "Новая конфигурация";
            lolGifPB.Visible = false;
            closeBtn.Visible = false;
        }

        private void updateConf_Click(object sender, EventArgs e)
        {
             confWorking = true;
             newCfgLabel.Text = "Дождитесь завершения операции обновления...";
           
        
            switch (newCfgText.Text)
            {
                case "ДИНРУС КОНСОЛЬ ОДИНОЧНАЯ":
                   scIniText.Lines =new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#DINRUS CONSOLE SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\dinrus\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   };     cf = SC.DCA;
                    break;

                case "РУЛАДА1 КОНСОЛЬ ОДИНОЧНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA1 CONSOLE SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Rulada -defaultlib=rulada.lib -debuglib=rulada.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   };        cf =SC.R1CA;
                    break;

                case "РУЛАДА2 КОНСОЛЬ ОДИНОЧНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA2 CONSOLE SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Dinrus -defaultlib=rulada.lib -debuglib=rulada.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf =SC.R2CA;
                    break;

                case "ДИНРУС КОНСОЛЬ ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#DINRUS CONSOLE FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\dinrus\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib -L+DRwin32.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.DWF;
                    break;

                case "РУЛАДА1 КОНСОЛЬ ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA1 CONSOLE FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Rulada -defaultlib=rulada.lib -debuglib=rulada.lib -L+derelict.lib+tango.lib+auxc.lib+auxd.lib+amigos.lib+arc.lib+gtkD.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf= SC.R1CF;
                    break;

                case "РУЛАДА2 КОНСОЛЬ ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA2 CONSOLE FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Rulada -defaultlib=rulada.lib -debuglib=rulada.lib -L+derelict.lib+tango.lib+auxc.lib+auxd.lib+amigos.lib+arc.lib+gtkD.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.R2CF;
                    break;

                case "ДИНРУС ОКНО ОДИНОЧНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#DINRUS WINDOW SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\dinrus\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib -L/exet:nt/su:windows:5.0", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.DWA;
                    break;

                case "РУЛАДА1 ОКНО ОДИНОЧНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA1 WINDOW SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   };  cf = SC.R1WA;
                    break;

                case "РУЛАДА2 ОКНО ОДИНОЧНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA1 WINDOW SINGLE", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.R2WA;
                    break;

                case "ДИНРУС ОКНО ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#DINRUS WINDOW FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\dinrus\" -O -version=Dinrus -defaultlib=dinrus.lib -debuglib=dinrus.lib -L+DRwin32.lib -L/exet:nt/su:windows:5.0", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.DWF;
                    break;

                case "РУЛАДА1 ОКНО ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA1 WINDOW FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Rulada -defaultlib=rulada.lib -debuglib=rulada.lib -L+derelict.lib+auxc.lib+tango.lib+auxd.lib+amigos.lib+arc.lib+gtkD.lib -L/exet:nt/su:windows:5.0 ", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.R1WF;
                    break;

                case "РУЛАДА2 ОКНО ПОЛНАЯ":
                    scIniText.Lines = new string[]
                   {
"[Version]",
"version=7.51 Build 020",
"","#RULADA2 WINDOW FULL", "",
"[Environment]",
"PATH=%PATH%;%DINRUS%;%BIN%",
"BIN=\"%@P%\\..\\bin\"",
"INCLUDE=\"%@P%\\..\\include\";%INCLUDE%",
"LIB=\"%@P%\\..\\lib\";\"%@P%\\..\\lib\\rulada\";\"%@P%\\..\\lib\\c\";\"%@P%\\..\\lib\\sysimport\";%LIB%",
"DFLAGS=\"-I%@P%\\..\\imp\\rulada\" -O -version=Rulada -defaultlib=rulada.lib -debuglib=rulada.lib -L+derelict.lib+auxc.lib+tango.lib+auxd.lib+amigos.lib+arc.lib+gtkD.lib -L/exet:nt/su:windows:5.0 ", 
"LINKCMD=%@P%\\dmlink.exe"          
                   }; cf = SC.R2WF;
                    break;            

            }


            System.IO.StreamWriter SW = new System.IO.StreamWriter(new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write), System.Text.Encoding.Default);
            

                foreach (string line in scIniText.Lines)
                {

                    {
                        SW.WriteLine(line);
                    }
                }

                SW.Close();

                Cursor.Current = Cursors.WaitCursor;
                 
      if (cf == SC.R1CA || cf == SC.R1CF ||cf == SC.R1WA || cf == SC.R1WF)
           {

               if (File.Exists(DINRUS + @"\\..\\imp\\rulada\\Версия_1.txt") && File.Exists(DINRUS + @"\\..\\lib\\rulada\\rulada.lib"))
               {
                   goto notifyOK;

               }

             if (Directory.Exists(DINRUS + @"\\..\\imp\\rulada"))
            {
                Directory.Delete(DINRUS + @"\\..\\imp\\rulada", true);
                newCfgLabel.Text = "Удаляется папка импорта ...";
            }

          //  byte[] imp = File.ReadAllBytes(DINRUS +@"\\..\\repos\\rulada1_imp.7z");
            
       /*      
            using( var extr = new BestCS.Compression.SevenZip.SevenZipExtractor(DINRUS +@"\\..\\repos\\rulada1_imp.7z"))
            {
                //извлечь импорт
                
                newCfgLabel.Text = "Извлечение файлов ...";
                try
                {
                    extr.ExtractArchive(DINRUS + @"\\..\\imp");                   
                    
                    cf = 0;
                }
                catch (Exception exc) { newCfgLabel.Text = exc.ToString(); return; }
                
            }
            
            
            if (Directory.Exists(DINRUS + @"\\..\\lib\\rulada"))
                Directory.Delete(DINRUS + @"\\..\\lib\\rulada", true);
            Directory.CreateDirectory(DINRUS + @"\\..\\lib\\rulada");
           // imp = File.ReadAllBytes(DINRUS + @"\\..\\repos\\rulada1_imp.7z");
            newCfgLabel.Text = "Замена библиотек импорта ...";
            
            using (var extr = new BestCS.Compression.SevenZip.SevenZipExtractor(DINRUS + @"\\..\\repos\\rulada1_libs.7z"))
            {
                try{
                    //извлечь библиотеки
                    extr.ExtractArchive(DINRUS + @"\\..\\lib\\rulada");
                    
                    cf = 0;
                }
                catch (Exception exc) { newCfgLabel.Text = exc.ToString(); return; }
                
            }

            */
        }

      else if (cf == SC.R2CA || cf == SC.R2CF || cf == SC.R2WA || cf == SC.R2WF)
           {

               if (File.Exists(DINRUS + @"\\..\\imp\\rulada\\Версия_2.txt") && File.Exists(DINRUS + @"\\..\\lib\\rulada\\rulada.lib"))
            {
                goto notifyOK;
            }
            
            if (Directory.Exists(DINRUS + @"\\..\\imp\\rulada"))
            {
                Directory.Delete(DINRUS + @"\\..\\imp\\rulada", true);
                newCfgLabel.Text = "Удаляется папка импорта ...";
            }

           // byte[] imp = File.ReadAllBytes(DINRUS +@"\\..\\repos\\rulada2_imp.7z");
            
            //удалить папку импорта Рулады
          /*  
            using( var extr = new BestCS.Compression.SevenZip.SevenZipExtractor(DINRUS +@"\\..\\repos\\rulada2_imp.7z"))
            {
                //извлечь импорт
                
                newCfgLabel.Text = "Извлечение файлов ...";
                try
                {
                    extr.ExtractArchive(DINRUS + @"\\..\\imp");                   
                    
                    cf = 0;
                }
                catch (Exception exc) { newCfgLabel.Text = exc.ToString(); return; }
                
            }
            
            */
            if (Directory.Exists(DINRUS + @"\\..\\lib\\rulada"))
                Directory.Delete(DINRUS + @"\\..\\lib\\rulada", true);
            Directory.CreateDirectory(DINRUS + @"\\..\\lib\\rulada");
          //  imp = File.ReadAllBytes(DINRUS + @"\\..\\repos\\rulada2_libs.7z");
            newCfgLabel.Text = "Замена библиотек импорта ...";
          /*  
            using (var extr = new BestCS.Compression.SevenZip.SevenZipExtractor(DINRUS + @"\\..\\repos\\rulada2_libs.7z"))
            {
                try{
                    //извлечь библиотеки
                    extr.ExtractArchive(DINRUS + @"\\..\\lib\\rulada");
                    
                    cf = 0;
                }
                catch (Exception exc) { newCfgLabel.Text = exc.ToString(); return; }
                
            }
          */
        }
      Cursor.Current = Cursors.Arrow;

       notifyOK:
            confWorking = false;
             newCfgLabel.Text = "Конфигурация обновлена";
             newCfgText.Visible = false;
             updateConf.Visible = false;
             lolGifPB.Visible = true;
             closeBtn.Visible = true;
        }


    

        private void saveScIni_Click(object sender, EventArgs e)
        {
           using( System.IO.StreamWriter SW = new System.IO.StreamWriter(new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write), System.Text.Encoding.Default))
            {
                foreach (string line in scIniText.Lines)
                {
                     
                    {
                        SW.WriteLine(line);
                    }
                }
                SW.Close();
              }
           finalize();

          }


        void finalize()
        {
            string message = "Файл " + file + " и \nрабочая конфигурация Динрус удачно обновлены";
            string caption = "Обновление Конфигурации Динрус";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);   
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(scIniText.ReadOnly == false) scIniText.ReadOnly = true;
            else if(scIniText.ReadOnly == true) scIniText.ReadOnly = false;

            if (saveScIni.Visible == false) saveScIni.Visible = true;
            else if (saveScIni.Visible == true) saveScIni.Visible = false; 
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }


}
