using MeuTerceiroApp.Model.Entities;
using MeuTerceiroApp.Storage;
using MeuTerceiroApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuTerceiroApp.View
{
    //Anotação do Xamarin para compilar a classe usando o XAML para a parte visual (!!Nunca mexa nesta anotação!!)
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //Declaração da classe e fazendo ela herdar das propriedades da TabbedPage
    public partial class MenuPrincipal : TabbedPage
    {
        //Declarações
        Frase objFrase;

        public MenuPrincipal()
        {
            //Método que inicializa os componentes visuais
            InitializeComponent();
            //Inserir os itens do banco de dados na lista
            MinhaListView.ItemsSource = new FraseViewModel().Listar();
            //definir o menu ao clicar na MinhaListView
            MinhaListView.ItemSelected += OnActionSheetSimpleClicked;
            //Instanciando o objeto
            objFrase = new Frase();
        }
        public MenuPrincipal(Frase frase)
        {
            //Método que inicializa os componentes visuais
            InitializeComponent();
            //Inserir os itens do banco de dados na lista
            MinhaListView.ItemsSource = new FraseViewModel().Listar();
            //Definindo binding
            BindingContext = frase;
            //Instanciando o objeto
            objFrase = new Frase();
            //Igualar a frase a ser editada com a frase do meu documento
            objFrase = frase;
            //definir o menu ao clicar na MinhaListView
            MinhaListView.ItemSelected += OnActionSheetSimpleClicked;

        }
        //Método de clique do botão Salvar
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MeuEntry.Text))
            {
                //Insere na propriedade da frase o valor digitado no campo
                objFrase.MinhaFrase = MeuEntry.Text;

                //Tentativa de salvar a frase, validando possíveis erros
                if (new FraseViewModel().SalvarFrase(objFrase))
                {
                    //Mensagem de successo ao salvar
                    DisplayAlert("Salvo com sucesso!", null, "Ok");
                    //Instanciando o objeto
                    objFrase = new Frase();
                    //Manda a ListView carregar a lista novamente
                    MinhaListView.ItemsSource = new FraseViewModel().Listar();
                }
                else
                {   
                    //Exibe a mensagem de erro
                    DisplayAlert("Houve um erro ao salvar!", null, "Ok");
                }          
                                  
                //Esvaziar o campo do formulário
                MeuEntry.Text = "";
            }
            else
            {
                //Mensagem de erro ao salvar
                DisplayAlert("Preencha um valor no campo!", null, "Ok");
            }
        }

        async void OnActionSheetSimpleClicked(Object sender, SelectedItemChangedEventArgs e)
        {
            var action = await DisplayActionSheet("Ação:", "Cancelar", null, "Editar", "Excluir");

            if (action.Equals("Editar"))
            {
                Frase fraseSelecionada = (Frase)e.SelectedItem;

                await Navigation.PushAsync(new MenuPrincipal(fraseSelecionada));

                MinhaListView.ItemSelected -= null;
            }
            else if (action.Equals("Excluir"))
            {
                var action2 = await DisplayActionSheet("Deseja deletar este credenciamento?", "Cancelar", null, "Sim", "Não");
                if (action2.Equals("Sim"))
                {
                    Frase fraseSelecionada = (Frase)e.SelectedItem;
                    if (fraseSelecionada == null)
                        return;
                    FraseDAO manager = new FraseDAO();
                    manager.DeleteValue(fraseSelecionada);
                    this.MinhaListView.ItemsSource = new FraseViewModel().Listar();

                    MinhaListView.ItemSelected -= null;
                }
            }
        }

        /*Eventos de foco do formulário de inserção*/
        //Campo com foco
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            //Mudança da cor do texto do label
            MeuLabel.TextColor = Color.CadetBlue;
            //Mudança na rotação do label (em graus)
            MeuLabel.RotationY = 22.5;
            //Mudança da cor do texto do entry
            MeuEntry.TextColor = Color.CadetBlue;
        }
        //Campo sem foco
        private void MeuEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(MeuEntry.Text))
            {
                //Mudança na rotação do label (em graus)
                MeuLabel.RotationY = -22.5;
                //Mudança da cor do texto do label
                MeuLabel.TextColor = Color.Red;
                //Mudança da cor do texto do entry
                MeuEntry.TextColor = Color.Red;
                //Mudança na rotação do entry (em graus)
                MeuEntry.RotationY = -22.5;
            }
            else
            {
                //Mudança na rotação do label (em graus)
                MeuLabel.RotationY = 0;
                //Mudança da cor do texto do label
                MeuLabel.TextColor = Color.CadetBlue;
                //Mudança da cor do texto do entry
                MeuEntry.TextColor = Color.CadetBlue;
                //Mudança na rotação do entry (em graus)
                MeuEntry.RotationY = 0;
            }
        }
    }
}