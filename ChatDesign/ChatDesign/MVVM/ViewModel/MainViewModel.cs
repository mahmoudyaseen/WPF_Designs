using ChatDesign.Core;
using ChatDesign.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesign.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        private ContactModel selectedContact;

        public ContactModel SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            {
                _message = value; 
                OnPropertyChanged(); 
            }
        }

        /* Commands */
        public RelayCommand SendCommand { get; set; }

        public MainViewModel()
        {
            Messages = new();
            Contacts = new();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = string.Empty;
            });

            Messages.Add(new MessageModel
            {
                Username = "Yaseen",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/nRKCEJp.jpeg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,
            });
            for (int i = 0; i < 3 ; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Yaseen",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/nRKCEJp.jpeg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }
            Messages.Add(new MessageModel
            {
                Username = "Arafa",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/tD2JzSd.jpeg",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,
            });
            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Arafa",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/tD2JzSd.jpeg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }
            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Yaseen {i + 1}",
                    ImageSource = "https://i.imgur.com/nRKCEJp.jpeg",
                    Messages = Messages
                });
            }
        }
    }
}
