using allopromo.Admin.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
namespace allopromo.Admin.Areas.Manage.Models
{
    public delegate void CategoryCreated(Object source, EventArgs e);
    public class CategoryService
    {
        public event EventHandler<CategoryCreatedEventArgs> Created;
        public event EventHandler<StoreCategoryCreatedEventArgs> Finished;
        public EventHandler<CategoryCreatedEventArgs> categoryCreated { get; set; }
        public EventHandler CategoryDesactivated;

        private readonly Subject<CategoryCreatedEventArgs> createdSubject;
        private readonly Subject<CategoryCreatedEventArgs> finishedSubject;

        public IObservable<CategoryCreatedEventArgs> Created43 { get { return createdSubject; } }
        public IObservable<CategoryCreatedEventArgs>  Finished23 { get { return finishedSubject; } }

        CategoryService()
        {
            createdSubject = new Subject<CategoryCreatedEventArgs>();
            finishedSubject = new Subject<CategoryCreatedEventArgs>();
        }
        protected virtual void OnCategoryCreated(CategoryCreatedEventArgs e)
        {
            if (categoryCreated != null)
            {
                categoryCreated(this, e);
            }
        }
        protected virtual void OnCategoryDesactive()
        {
            var handler = CategoryDesactivated;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        public void  NotyAll()
        {
            OnCategoryCreated(new CategoryCreatedEventArgs());
        }
        public void Start()
        {
            Task.Run((Action)DoStuff);
            //Task.Run(() => DoStuff());
        }
        private void DoStuff()
        {
            try
            {

            }
            catch
            {

            }
        }
    }
    public class NotifyService
    {
        private CategoryService _categoryService { get; set; }
        public NotifyService(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void NotifySubscriber()
        {
            _categoryService.categoryCreated += NotifyMe;
            _categoryService.NotyAll();
        }
        private void NotifyMe(object source, EventArgs e)
        {
        }
    }
}
//
// Systeme de Tracking | Anaxar | Marc Biegniebe , Arnorld Amouzou
//Etapes de Logistiques | Geolocolosation en temps Reels , Garantir , 
//Accelerer le, 8h20 .
// Appel a Plisuers Processus - Logiciels | Pouvoirs Publics 
//Pblm  d Acces au Financement | Implemeting des processus par les pouvoirs publics - 
//Mise en Place d'une Reglementation 

//?  Iterator Pattern : IEnumerator<T> vs IEnumerable<T> ? -> Interactive Programming 
//interactive programming vs Reactive programming ?
//Reactive programming : aka Push Patterns , used in UI heavy application, Silverlight
// Reactive extension interface : IObservable<T> , IObserver<T> 


//Jan Van Osselberg

//

//public class  relative to Reactive ext ? -- What was I trying to do  or Asynchroning ?