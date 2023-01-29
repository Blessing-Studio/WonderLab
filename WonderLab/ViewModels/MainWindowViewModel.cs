using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderLab.Modules.Base;
using WonderLab.Modules.Const;
using WonderLab.Modules.Controls;
using WonderLab.Modules.Models;

namespace WonderLab.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<InfoBarModel> InfoBarItems
        {
            get => _InfoBarItems;
            set => RaiseAndSetIfChanged(ref _InfoBarItems, value);
        }

        private ObservableCollection<InfoBarModel> _InfoBarItems = new();

        public static MainWindowViewModel ViewModel;

        public static TitleBar TitleBar { get; set; }

        public Window Window;

        public MainWindowViewModel(Window window)
        {
            Window = window;
            ViewModel = this;
        }

        public void Colse() => TitleBar.OnClose();
        public void MaxWindowSize() => TitleBar.OnRestore();
        public void MiniWindowSize() => TitleBar.OnMinimize();

        /// <summary>
        /// ��Ӱ����ק��װ����
        /// </summary>
        public void ShaderPacksInstallAction() {
            if (string.IsNullOrEmpty(App.Data.FooterPath) || string.IsNullOrEmpty(App.Data.SelectedGameCore)) {
                MainWindow.win.CloseAnimaction();
                MainWindow.ShowInfoBarAsync("����", "��û��ѡ����ϷĿ¼����Ϸ���ģ��޷�������װ��Ӱ��", InfoBarSeverity.Error);
                return;
            }

            var saveDirpath = PathConst.GetShaderPacksFolder(App.Data.FooterPath, App.Data.SelectedGameCore!);
            Trace.WriteLine($"[��Ϣ]��Ӱ�����������Ŀ¼Ϊ {saveDirpath}");

            try {
                if (!Directory.Exists(saveDirpath)) {
                    Directory.CreateDirectory(saveDirpath);
                }

                File.Copy(MainWindow.win.FileNames.First(),
                          Path.Combine(saveDirpath, Path.GetFileName(MainWindow.win.FileNames.First())), true);

                MainWindow.ShowInfoBarAsync("�ɹ�", $"��Ӱ���ѳɹ���װ��ѡ�����Ϸ���ģ�", InfoBarSeverity.Success);

                if (MainWindow.win.FileNames.Count > 1) {
                    MainWindow.ShowInfoBarAsync("��ʾ", "�������˶���ļ���WonderLab��ѡȡ��һ����װ���������ظ��˲�����");
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowInfoBarAsync("����", $"WonderLab �ڰ�װ��Ӱ��ʱ������һЩ�����������쳣���쳣��ջ���£�\n{ex}", InfoBarSeverity.Error);
            }finally {
                MainWindow.win.CloseAnimaction();
            }
        }

        /// <summary>
        /// ���ʰ���ק��װ����
        /// </summary>
        public void ResourcePacksInstallAction()
        {
            if (string.IsNullOrEmpty(App.Data.FooterPath) || string.IsNullOrEmpty(App.Data.SelectedGameCore))
            {
                MainWindow.win.CloseAnimaction();
                MainWindow.ShowInfoBarAsync("����", "��û��ѡ����ϷĿ¼����Ϸ���ģ��޷�������װ���ʰ�", InfoBarSeverity.Error);
                return;
            }

            var saveDirpath = PathConst.GetResourcePacksFolder(App.Data.FooterPath, App.Data.SelectedGameCore!);
            Trace.WriteLine($"[��Ϣ]���ʰ����������Ŀ¼Ϊ {saveDirpath}");

            try
            {
                if (!Directory.Exists(saveDirpath))
                {
                    Directory.CreateDirectory(saveDirpath);
                }

                File.Copy(MainWindow.win.FileNames.First(),
                          Path.Combine(saveDirpath, Path.GetFileName(MainWindow.win.FileNames.First())), true);

                MainWindow.ShowInfoBarAsync("�ɹ�", $"���ʰ��ѳɹ���װ��ѡ�����Ϸ���ģ�", InfoBarSeverity.Success);

                if (MainWindow.win.FileNames.Count > 1)
                {
                    MainWindow.ShowInfoBarAsync("��ʾ", "�������˶���ļ���WonderLab��ѡȡ��һ����װ���������ظ��˲�����");
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowInfoBarAsync("����", $"WonderLab �ڰ�װ���ʰ�ʱ������һЩ�����������쳣���쳣��ջ���£�\n{ex}", InfoBarSeverity.Error);
            }
            finally
            {
                MainWindow.win.CloseAnimaction();
            }
        }

        /// <summary>
        /// ģ�����ק��װ����
        /// </summary>
        public void ModnstallAction()
        {
            if (string.IsNullOrEmpty(App.Data.FooterPath) || string.IsNullOrEmpty(App.Data.SelectedGameCore))
            {
                MainWindow.win.CloseAnimaction();
                MainWindow.ShowInfoBarAsync("����", "��û��ѡ����ϷĿ¼����Ϸ���ģ��޷�������װģ��", InfoBarSeverity.Error);
                return;
            }

            var saveDirpath = PathConst.GetModsFolder(App.Data.FooterPath, App.Data.SelectedGameCore!);
            Trace.WriteLine($"[��Ϣ]ģ�齫�������Ŀ¼Ϊ {saveDirpath}");

            try
            {
                if (!Directory.Exists(saveDirpath))
                {
                    Directory.CreateDirectory(saveDirpath);
                }

                File.Copy(MainWindow.win.FileNames.First(),
                          Path.Combine(saveDirpath, Path.GetFileName(MainWindow.win.FileNames.First())), true);

                MainWindow.ShowInfoBarAsync("�ɹ�", $"ģ���ѳɹ���װ��ѡ�����Ϸ���ģ�", InfoBarSeverity.Success);

                if (MainWindow.win.FileNames.Count > 1)
                {
                    MainWindow.ShowInfoBarAsync("��ʾ", "�������˶���ļ���WonderLab��ѡȡ��һ����װ���������ظ��˲�����");
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowInfoBarAsync("����", $"WonderLab �ڰ�װģ��ʱ������һЩ�����������쳣���쳣��ջ���£�\n{ex}", InfoBarSeverity.Error);
            }
            finally
            {
                MainWindow.win.CloseAnimaction();
            }
        }
    }
}
