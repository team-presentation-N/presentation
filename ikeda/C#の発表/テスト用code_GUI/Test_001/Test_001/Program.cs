using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_001
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
            //メインスレッドで発生し,ハンドルされなかった例外を処理するThreadExceptionイベントハンドラを追加
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            */

            //App.configの設定に依らず,ThreadExceptionが発生しないようにする
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            //他スレッドで発生し,ハンドルされなかった例外を処理するUnhandledExceptionイベントハンドラを追加
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program_UnhandledException);

            Application.Run(new Form1());
        }

        /*
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                //エラーメッセージをウィンドウに表示する
                MessageBox.Show(e.Exception.Message, "ThreadException");
            }
            finally
            {
                Application.Exit();
            }
        }
        */

        static void Program_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                //エラーメッセージをウィンドウに表示する
                MessageBox.Show(((Exception)e.ExceptionObject).Message, "UnhandledException");
            }
            finally
            {
                //アプリケーションを終了する
                Environment.Exit(1);
            }
        }
    }
}
