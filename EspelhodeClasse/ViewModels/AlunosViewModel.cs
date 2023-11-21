using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EspelhodeClasse.Models;

namespace EspelhodeClasse.ViewModels;
internal class AlunosViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.AlunoViewModel> AllAlunos { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectAlunoCommand { get; }

    public AlunosViewModel()
    {
        AllAlunos = new ObservableCollection<ViewModels.AlunoViewModel>(Models.Aluno.LoadAll().Select(n => new AlunoViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewAlunoAsync);
        SelectAlunoCommand = new AsyncRelayCommand<ViewModels.AlunoViewModel>(SelectAlunoAsync);
    }

    private async Task NewAlunoAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.Aluno));
    }
    private async Task SelectAlunoAsync(ViewModels.AlunoViewModel aluno)
    {
        if (aluno != null)
        {
            await Shell.Current.GoToAsync($"{nameof(Views.Aluno)}?load={aluno.Identifier}");
        }
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("deleted"))
        {
            string alunoId = query["deleted"].ToString();
            AlunoViewModel matchedAluno = AllAlunos.Where((n) => n.Identifier == alunoId).FirstOrDefault();

            // Se achar a anotação, delete ela
            if (matchedAluno != null)
                AllAlunos.Remove(matchedAluno);
        }
        else if (query.ContainsKey("saved"))
        {
            string alunoId = query["saved"].ToString();
            AlunoViewModel matchedAluno = AllAlunos.Where((n) => n.Identifier == alunoId).FirstOrDefault();

            // Se achar a anotação, atualize ela
            if (matchedAluno != null)
            {
                matchedAluno.Reload();
                AllAlunos.Move(AllAlunos.IndexOf(matchedAluno), 0);
            }

            // Se não achar a anotação, é nova; Adicione ela.
            else
                AllAlunos.Insert(0, new AlunoViewModel(Aluno.Load(alunoId)));
        }
    }
}
