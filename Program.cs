
namespace tp1
{

    //encapusulation
    public class Activity
    {
        public string Title { get; set; }

        private protected int Temps { get; set; }

        public string Description { get; set; }

        private bool _isCompleted;

        // Méthode virtuelle pour le polymorphisme
        protected virtual void DisplayInfo()
        {
            Console.WriteLine("Affichage de l'activité");
        }

    }

    // héritage + encapusulation
    public class SubActivity : Activity
    {
        public string UtilisLink;
        public DateTime Datedebut;

        public DateTime Datefin;

        public string Commentaire;

        private string _etat;

        public string Etat
        {
            get => _etat;
            private set => _etat = value;
        }
        protected internal void updateState(string value)
        {
            Etat = value;
        }

        protected override void DisplayInfo()
        {
            Console.WriteLine("Affichage de la sous-activité");
        }

    }

    // utilisation d'interface

    interface ISubActivityService
    {
        void CompletedSubActivity(SubActivity subActivity);
    }

    public class SubActivityService : ISubActivityService
    {
        public void CompletedSubActivity(SubActivity subActivity)
        {
            if (subActivity.Datefin <= DateTime.Now)
            {
                subActivity.updateState("Finished");
                Console.WriteLine("L'evenement et terminer");
            }
        }
    }

    // Polymorphisme
    public abstract class Fullstack
    {
        public virtual void Developpe()
        {
            Console.WriteLine("je suis developpeur backend et frontend :)");
        }
    }

    public class Frontend : Fullstack
    {
        public override void Developpe()
        {
             Console.WriteLine("je suis developpeur frontend :)");
        }
    }

    public class Backend : Fullstack
    {
        public override void Developpe()
        {
             Console.WriteLine("je suis developpeur backend :)");
        }
    }
}