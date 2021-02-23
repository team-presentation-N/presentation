using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace FileCopyProgressTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("開始");

            //進捗表示付きでコピーを実行
            FileCopyClass.Start(@"D:\BackupTest2\2021_01_30_14_03_03_All\march's world", @"D:\dest");

            //進捗表示を行わないバージョン
            //FileCopyClass2.CopyDirectory(@"D:\BackupTest2\2021_01_30_14_03_03_All\march's world", @"D:\dest");

            sw.Stop();
            Console.WriteLine("終了 経過時間:" + sw.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }
    }

    static class FileCopyClass
    {
        public static void Start(string source, string dest)
        {
            if (Directory.Exists(dest))
            {
                Console.WriteLine("destが既に存在するのでキャンセルされました");
                return;
            }

            if (!Directory.Exists(source))
            {
                Console.WriteLine("sourceが存在しないのでキャンセルされました");
                return;
            }

            var info = new CopyInfo();

            GetDirectorySizeAndFileCount(source, info);

            Console.WriteLine("コピー対象のサイズ:" + info.SizeAmount/1024/1024 + "MB");
            Console.WriteLine("コピー対象のファイル数:" + info.CountAmount);

            //Console.WriteLine("キー押下で続行");
            //Console.ReadKey();
            CopyDirectoryWithProgress(source, dest, info);
        }

        static void GetDirectorySizeAndFileCount(string path, CopyInfo info)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            //対象ディレクトリ直下のファイルサイズ総和
            foreach (FileInfo fi in di.GetFiles())
            {
                info.AddAmount(fi.Length);
            }
            //対象ディレクトリ直下のサブディレクトリに再帰的に実行
            foreach (DirectoryInfo sdi in di.GetDirectories())
            {
                GetDirectorySizeAndFileCount(sdi.FullName, info);
            }
        }

        static void CopyDirectoryWithProgress(string source, string dest, CopyInfo info)
        {
            Directory.CreateDirectory(dest);
            DirectoryInfo di = new DirectoryInfo(source);
            //対象ディレクトリ直下のファイルを全てdest直下にコピー
            Parallel.ForEach(di.GetFiles(), fi =>
            {
                //ファイルの完全パスを取得してStream生成
                using (FileStream srcfs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //"dest + 上のファイル名"に書き込むStreamを生成                
                using (FileStream destfs = new FileStream(Path.Combine(dest, fi.Name), FileMode.Create))
                {
                    try
                    {
                        srcfs.CopyTo(destfs);
                        info.AddCompteled(fi.Length);
                        Console.WriteLine("完了:" + srcfs.Name + " => " + destfs.Name);
                        Console.WriteLine("コピー進捗  " + info.CompletedCount + "/" + info.CountAmount
                                                  + "  " + info.CompletedSize/1024/1024 + "/" + info.SizeAmount/1024/1024 + "MB");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("コピー失敗:" + srcfs.Name);
                    }
                }
            });

            //対象ディレクトリ直下のサブディレクトリに再帰的に実行
            Parallel.ForEach(di.GetDirectories(), sdi =>
            {
                CopyDirectoryWithProgress(sdi.FullName, Path.Combine(dest, sdi.Name), info);
            });
        }
    }

    public class CopyInfo
    {
        public long SizeAmount { private set; get; } = 0;
        public int CountAmount { private set; get; } = 0;
        public long CompletedSize { private set; get; } = 0;
        public int CompletedCount { private set; get; } = 0;

        public void AddAmount(long size)
        {
            SizeAmount += size;
            CountAmount++;
        }
        public void AddCompteled(long size)
        {
            CompletedSize += size; 
            CompletedCount++;
        }
    }

    static class FileCopyClass2
    {
        public static void CopyDirectory(string sourcepath, string destpath)
        {
            Directory.CreateDirectory(destpath);
            DirectoryInfo di = new DirectoryInfo(sourcepath);
            //対象ディレクトリ直下のファイルを全てdest直下にコピー
            Parallel.ForEach(di.GetFiles(), fi =>
            {
                //ファイルの完全パスを取得してStream生成
                using (FileStream srcfs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //"dest + 上のファイル名"に書き込むStreamを生成                
                using (FileStream destfs = new FileStream(Path.Combine(destpath, fi.Name), FileMode.Create))
                {
                    try
                    {
                        srcfs.CopyTo(destfs);
                    }
                    catch (IOException ex)
                    {
                        Debug.WriteLine("失敗：" + destfs.Name + "\n" + ex.Message);
                    }
                }
            });

            //対象ディレクトリ直下のサブディレクトリに再帰的に実行
            Parallel.ForEach(di.GetDirectories(), sdi =>
            {
                CopyDirectory(sdi.FullName, Path.Combine(destpath, sdi.Name));
            });
        }
    }
}
