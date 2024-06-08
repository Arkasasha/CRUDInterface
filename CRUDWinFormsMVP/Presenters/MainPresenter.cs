using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDWinFormsMVP.Views;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP._Repositories;


namespace CRUDWinFormsMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string mySqlConnectionString;

        public MainPresenter(IMainView mainView, string mySqlConnectionString)
        {
            this.mainView = mainView;
            this.mySqlConnectionString = mySqlConnectionString;
            this.mainView.ShowUserView += ShowUsersView;
        }

        private void ShowUsersView(object sender, EventArgs e)
        {
            IUserView view = UserView.GetInstance((MainView)mainView);
            IUserRepository repository = new UserRepository(mySqlConnectionString);
            new UserPresenter(view, repository);
        }
    }
}
