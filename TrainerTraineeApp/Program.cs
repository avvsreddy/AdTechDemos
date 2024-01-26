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

            // create trainees and add to training
            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);


            Console.WriteLine($"No. of trainees: {training.GetNumberOfTrainees()}");

            Course course = new Course();
            training.Course = course;
            Module m1 = new Module();
            Module m2 = new Module();
            Module m3 = new Module();
            course.Modules.Add(m1);
            course.Modules.Add(m2);
            course.Modules.Add(m3);

            Unit u1 = new Unit();
            u1.Duration = 5;
            Unit u2 = new Unit { Duration = 10 };
            m1.Units.Add(u1);
            m1.Units.Add(u2);

            Unit u3 = new Unit { Duration = 10 };
            Unit u4 = new Unit { Duration = 10 };
            m2.Units.Add(u3);
            m2.Units.Add(u4);
            Unit u5 = new Unit { Duration = 10 };
            m3.Units.Add(u5);




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
        public Course Course { get; set; }
        public string GetTrainingOrgName()
        {
            // return training org name
            return TheTrainer.TheOrganization.Name;
        }

        public int GetNumberOfTrainees()
        {
            // count the no. of participants and return

            return Trainees.Count;
        }

        public int GetTrainingDurationInHrs()
        {
            // calculate the duration and return
            int totDuration = 0;
            // for each modules
            foreach (var module in Course.Modules)
            {
                // for each unit
                foreach (var unit in module.Units)
                {
                    totDuration += unit.Duration;
                }
            }

            return totDuration;
        }
    }

    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();
    }
    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    class Topic
    {
        public string Name { get; set; }
    }
}
