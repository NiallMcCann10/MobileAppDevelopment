using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    /*
 * IPageService is an abstraction (contract) that represents the services
 * that a page can provide.
 * Going to work with this interface
 *  Don't know what is behind the interface or what class has implemented
 *  it
 * Can decouple from Xamarin in order to faciliate the navigation call.
 * Will have to implement the class also
 */

    public interface IPageService
    {
        Task PushAsnyc(Page page);
        Task<bool> DisplayAlert(string title, string message,
                                string ok, string cancel);
    }
}
