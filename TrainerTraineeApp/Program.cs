namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // display training org name
            Training training = new Training();
            Trainer trainer = new Trainer();
            training.TheTrainer = trainer;

            Organization org = new Organization { Name = "AdTech Corporation" };
            trainer.TheOrganization = org;

            Console.WriteLine($"The Training Org Name : {training.GetTrainingOrgName()}");
            Console.WriteLine($"No. of trainees: {training.GetNumberOfTrainees()}");
            Console.WriteLine($"Training Duration in Hours: {training.GetTrainingDurationInHrs()}");
        }
    }

    class Organization
    {
        public string Name { get; set; }
    }
    class Trainer
    {
        public Organization TheOrganization { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }

    class Trainee
    {
        public Trainer TheTrainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }

    class Training
    {
        public Trainer TheTrainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public string GetTrainingOrgName()
        {
            // return training org name
            return TheTrainer.TheOrganization.Name;
        }

        public int GetNumberOfTrainees()
        {
            // count the no. of participants and return
            return 0;
        }

        public int GetTrainingDurationInHrs()
        {
            // calculate the duration and return
            return 0;
        }
    }
}
