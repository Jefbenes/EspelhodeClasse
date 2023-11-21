using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.ComponentModel;

namespace EspelhodeClasse.ViewModels;
internal class AlunoViewModel : ObservableObject, IQueryAttributable
{
    private Models.Aluno _aluno;
    public string Text
    {
        get => _aluno.Text;
        set
        {
            if (_aluno.Text != value)
            {
                _aluno.Text = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date => _aluno.Date;
    public string Identifier => _aluno.Filename;
    public ICommand SaveCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }
    public AlunoViewModel()
    {
        _aluno = new Models.Aluno();
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }
    public AlunoViewModel(Models.Aluno aluno)
    {
        _aluno = aluno;
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }
    private async Task Save()
    {
        _aluno.Date = DateTime.Now;
        _aluno.Save();
        string a = $"..?saved={_aluno.Filename}";
        await Shell.Current.GoToAsync(a);
    }
    private async Task Delete()
    {
        _aluno.Delete();
        await Shell.Current.GoToAsync($"..?deleted={_aluno.Filename}");
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            _aluno = Models.Aluno.Load(query["load"].ToString());
            RefreshProperties();
        }
    }
    public void Reload()
    {
        _aluno = Models.Aluno.Load(_aluno.Filename);
        RefreshProperties();
    }
    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Date));
    }
}
