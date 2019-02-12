#region

using System;
using System.Collections.Generic;
using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.CpdViewModels
{
    public class CpdAddEventViewModel : BaseViewModel
    {
        private readonly Database db;
        private static int? key = null;

        public CpdAddEventViewModel(int? Key = null)
        {
            key = Key;
            db = new Database();

            //Minimise this to save space, will remove later when database is confirmed

            #region Catagory stuff

            EmploymentSubCatagory = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "Full Time (Years)",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Years)"), 12.0)
                },
                {
                    "Full Time (Months)",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Months)"), 1.0)
                },
                {
                    "Part Time",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Fraction of full time equiv. over 12 months)"), 12.0)
                },
            };

            SIRTSubCatatgory = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "Module 1",
                    Tuple.Create(
                        Tuple.Create("Diagnostic Andrology, Semen Analysis, Anti-Sperm Antibody",
                            "Quantity (Signed Certificate)"), 10.0)
                },
                {
                    "Module 2",
                    Tuple.Create(
                        Tuple.Create("Sperm Preparation, Sperm Cryopresivation, Surgical Sperm Collection Preparation",
                            "Quantity (Signed Certificate)"), 10.0)
                },
                {
                    "Module 3",
                    Tuple.Create(
                        Tuple.Create(
                            "Basic Embtyology - Egg Collection, Conventional Insemination, Fertilisaation Checks, Embryo Checks/Transfers, Media Setup",
                            "Quantity (Signed Certificate)"), 20.0)
                },
                {
                    "Module 4",
                    Tuple.Create(
                        Tuple.Create(
                            "Cryopreservation - Manual Vitrification and Warming/Automated Virtrification and Warming/Slow Freeze and Thawing",
                            "Quantity (Signed Certificate)"), 10.0)
                },
                {
                    "Module 5",
                    Tuple.Create(
                        Tuple.Create("ICSI - Intracytoplasmic Sperm Injection", "Quantity (Signed Certificate)"), 20.0)
                },
                {
                    "Module 6",
                    Tuple.Create(
                        Tuple.Create("Biopsy And Cell To Tube Procedures", "Quantity (Signed Certificate"), 10.0)
                }
            };

            AttendanceAtScientificMeetings = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "International To Regional Scientific Meeting",
                    Tuple.Create(
                        Tuple.Create("International, National, State, Divisional, Regional Scientific Meetings",
                            "Quantity (Half days attended)"), 5.0)
                },
                {
                    "Short Course Or Workshop",
                    Tuple.Create(
                        Tuple.Create("Related To a Scientific Meeting", "Quantity (Half days attended)"), 5.0)
                },
                {
                    "Special Interest Group Meetings (SIG)",
                    Tuple.Create(
                        Tuple.Create("Not workplace related", "Quantity (Meetings attended)"), 2.0)
                },
                {
                    "Scientific Seminars/Research Forums/Lunchtime Meetings/Webinars",
                    Tuple.Create(
                        Tuple.Create("Not workplace clinical case reviews", "Quantity (Meetings attended)"), 1.0)
                },
                {
                    "AACB Tutorials",
                    Tuple.Create(
                        Tuple.Create("Australasian Association of Clinical Biochemists (AACB) Tutorials",
                            "Quantity (Hours attended)"), 1.0)
                }
            };

            PresentationAtMeetings = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "National to Regional Scientific Meeting or NZ SIG Meeting",
                    Tuple.Create(
                        Tuple.Create(
                            "National, State, Divisional, Regional Scientific Meeting or New Zealand SIG Meeting",
                            "Quantity (Per presentation)"), 10.0)
                },
                {
                    "Workshop Presentation",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per full day presentation)"), 20.0)
                },
                {
                    "Presentation of a Poster",
                    Tuple.Create(
                        Tuple.Create("Half credits if Co-Author but not the Presenter", "Quantity (Per presentation)"),
                        5.0)
                },
                {
                    "Australian SIG or Recognised Workplace, Seminars, Research Fourms",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per presentation)"), 5.0)
                },
                {
                    "Presentation at AACB Tutorial",
                    Tuple.Create(Tuple.Create("-", "Quantity (Per presentation)"), 5.0)
                }
            };

            Publications = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "Primary Author of an Article Published in a Peer Reviewed Scientific Journal",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Articles published)"), 20.0)
                },
                {
                    "Secondary Author of an Article Published in a Peer Reviewed Scientific Journal",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Articles published)"), 10.0)
                },
                {
                    "Scientific Article Reviewed",
                    Tuple.Create(
                        Tuple.Create(
                            "Reviewed for a peer reviewed journal such as the AJMS - Provide details of journal",
                            "Quantity (Reviews published)"), 5.0)
                },
                {
                    "Book Review",
                    Tuple.Create(
                        Tuple.Create("Published a review of a Scientific Publication", "Quantity (Reviews published)"),
                        1.0)
                }
            };

            WashingtonUniversityOnline = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "Per Examination Unit Passed",
                    Tuple.Create(
                        Tuple.Create("Maximum 30 CEU", "Quantity (Examination units passed)"), 5.0)
                },
                {
                    "MTS Webinar",
                    Tuple.Create(
                        Tuple.Create("Maximum 30 CEU - 1 CEU with 80% correct", "Quantity (Per webinar completed)"),
                        1.0)
                },
                {
                    "Per Hour Of Online Instruction",
                    Tuple.Create(
                        Tuple.Create("Maximum 30 CEU", "Quantity (Hours of online instruction)"), 1.0)
                }
            };

            StructuredReading = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "Per Questionnaire Answered Correctly From AJMS",
                    Tuple.Create(
                        Tuple.Create("24 CEU max per accredation period claim",
                            "Quantity (Querstionnaires answered correctly)"), 3.0)
                }
            };

            PostGraduateStudies = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "PhD or Fellowship of AIMS/AACB/ASM/RCPA",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Courses completed)"), 200.0)
                },
                {
                    "Masters Degree",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Courses completed)"), 100.0)
                },
                {
                    "Honours",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Courses completed)"), 40.0)
                },
                {
                    "MAACB",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity"), 40.0)
                },
                {
                    "Graduate Diploma",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Diplomas completed)"), 40.0)
                },
                {
                    "Graduate Certificate",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Certificates completed)"), 20.0)
                }
            };

            ProfessionalService = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "National to Regional Committee for AIMS/AACB/ASM/FSA/ASTH/ANZSBT",
                    Tuple.Create(
                        Tuple.Create(
                            "National, State, Divisional, Regional committee for AIMS, AACB, ASM, FSA, ASTH, ANZSBT",
                            "Quantity (Years of service)"), 10.0)
                },
                {
                    "Serving on National Scientific Meeting Committee",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per year)"), 10.0)
                },
                {
                    "Examinations Council Membership",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per year)"), 10.0)
                },
                {
                    "NATA/IANZ Assessor",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per day)"), 10.0)
                },
                {
                    "NPAAC Document Preparation",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per year)"), 10.0)
                },
                {
                    "Accrediation of University Courses",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per year)"), 10.0)
                },
                {
                    "Serving on Australian SIG Organising Committee",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Per year)"), 5.0)
                },
                {
                    "Supervison of PhD, Masters Or Honours Students",
                    Tuple.Create(
                        Tuple.Create("Maximum 20 CEU Per Year - Provide title of proposed thesis and institution",
                            "Quantity (Per year)"), 5.0)
                }
            };

            OtherActivities = new Dictionary<string, Tuple<Tuple<string, string>, double>>()
            {
                {
                    "AIMS Video Recordings",
                    Tuple.Create(
                        Tuple.Create("25 Maximum Per Application", "Quantity (Per video watched)"), 1.0)
                },
                {
                    "Completion of a FertAid Module",
                    Tuple.Create(
                        Tuple.Create("Printout of completion certificate is required for all modules - Not QAP",
                            "Quantity (Modules completed)"), 5.0)
                },
                {
                    "Professional/Scientific/Educational Project Development",
                    Tuple.Create(
                        Tuple.Create("-", "Quantity (Days of service)"), 3.0)
                },
                {
                    "Relevent Online Instruction Sites",
                    Tuple.Create(
                        Tuple.Create("Site must be cited - Maximum 30 CEU", "Quantity (Hours of online instruction)"),
                        2.0)
                },
                {
                    "BloodSafe eLearning Instruction",
                    Tuple.Create(
                        Tuple.Create("Please cite web address in further details entry",
                            "Quantity (Per hours of online instruction)"), 1.0)
                },
                {
                    "Publication of Short Scientific/Laboratory Related Articles",
                    Tuple.Create(
                        Tuple.Create("Not peer reviewed", "Quantity (Articles published)"), 1.0)
                },
                {
                    "Literature Searches for Relevant Topics/Articles",
                    Tuple.Create(
                        Tuple.Create("Please cite web address in further details entry",
                            "Quantity (Hours spent searching)"), 1.0)
                },
                {
                    "Reading of Professional Articles in Journals",
                    Tuple.Create(
                        Tuple.Create("Maximum 20 CEU per application", "Quantity (Articles read)"), 5.0)
                },
                {
                    "Teleconferences Relevant to Medical Science",
                    Tuple.Create(
                        Tuple.Create("Not workplace related - Provide subject matter",
                            "Quantity (Teleconferences completed)"), 1.0)
                }
            };

            CatagoryList = new Dictionary<string, Dictionary<string, Tuple<Tuple<string, string>, double>>>()
            {
                {"Employment", EmploymentSubCatagory},
                {"SIRT", SIRTSubCatatgory},
                {"Attendance at Scientific Meetings", AttendanceAtScientificMeetings},
                {"Presentation at Meetings", PresentationAtMeetings},
                {"Publications", Publications},
                {"Structured Reading", StructuredReading},
                {"Post Graduate Studies", PostGraduateStudies},
                {"Professional Service", ProfessionalService},
                {"Other Activities", OtherActivities}
            };

            #endregion

            SubmitCommand = new Command(RequiredFieldsFilled);
            catagories.AddRange(CatagoryList.Keys);

            subCatagoryDetails = "-";
            QuantityType = "Quantity";

            //If it's a fresh Add
            if (Key == null)
            {
                catagorySelectedIndex = -1;
                subCatagorySelectedIndex = -1;
                dateCompleted = DateTime.Now;
                documentUploadText = "No document selected.";
                SubCatagories = new List<string>();
            }

            //If it's an edit
            else
            {
                //Just to avoid issues with the content of the lists
                catagorySelectedIndex = -1;
                subCatagorySelectedIndex = -1;

                //Populate the form
                ActivityModel activity = db.GetActivity((int) Key);
                CatagorySelectedIndex = catagories.IndexOf(activity.Catagory);
                SubCatagorySelectedIndex = SubCatagories.IndexOf(activity.SubCatagory);
                ShortDescription = activity.ShortDescription;
                DateCompleted = activity.DateCompleted;
                FurtherDetails = activity.FurtherDetails;
                Quantity = activity.Quantity;
                LongDescription = activity.LongDescription;
                if (activity.SupportingDocument != null)
                {
                    DocumentUploadText = activity.SupportingDocument;
                }
            }
        }

        private List<string> catagories = new List<string>();

        public List<string> Catagories => catagories;

        public string SelectedCatagory;

        private int catagorySelectedIndex;

        public int CatagorySelectedIndex
        {
            get { return catagorySelectedIndex; }
            set
            {
                if (catagorySelectedIndex != value)
                {
                    catagorySelectedIndex = value;
                    //Sets the currently selected Catagory
                    SelectedCatagory = Catagories[catagorySelectedIndex];

                    //Creates a new list of subcatagories
                    SubCatagories = new List<string>();
                    SubCatagories.AddRange(CatagoryList.GetValueOrDefault(SelectedCatagory).Keys);
                    subCatagorySelectedIndex = -1;
                    SelectedSubCatagory = null;

                    QuantityType = "Quantity";

                    OnPropertyChanged();
                }
            }
        }

        public List<string> SubCatagories;

        public string SelectedSubCatagory;
        private int subCatagorySelectedIndex;

        public int SubCatagorySelectedIndex
        {
            get { return subCatagorySelectedIndex; }
            set
            {
                if (subCatagorySelectedIndex != value)
                {
                    subCatagorySelectedIndex = value;

                    //Sets the Current Subcatagory
                    SelectedSubCatagory = SubCatagories[subCatagorySelectedIndex];

                    //Shows the details if avalable
                    SubCatagoryDetails = CatagoryList.GetValueOrDefault(SelectedCatagory)
                        .GetValueOrDefault(SelectedSubCatagory).Item1.Item1;
                    QuantityType = CatagoryList.GetValueOrDefault(SelectedCatagory)
                        .GetValueOrDefault(SelectedSubCatagory).Item1.Item2;
                    NumPoints = CatagoryList.GetValueOrDefault(SelectedCatagory).GetValueOrDefault(SelectedSubCatagory)
                        .Item2;

                    OnPropertyChanged();
                }
            }
        }

        private string subCatagoryDetails;

        public string SubCatagoryDetails
        {
            get { return subCatagoryDetails; }
            set
            {
                subCatagoryDetails = value;
                OnPropertyChanged();
            }
        }

        private string shortDescription;

        public string ShortDescription
        {
            get { return shortDescription; }
            set
            {
                shortDescription = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateCompleted;

        public DateTime DateCompleted
        {
            get { return dateCompleted; }
            set
            {
                dateCompleted = value.Date;
                OnPropertyChanged();
            }
        }

        private string furtherDetails;

        public string FurtherDetails
        {
            get { return furtherDetails; }
            set
            {
                furtherDetails = value;
                OnPropertyChanged();
            }
        }

        private string quantityType;

        public string QuantityType
        {
            get { return quantityType; }
            set
            {
                quantityType = "*" + value;
                OnPropertyChanged();
            }
        }

        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        private string longDescription;

        public string LongDescription
        {
            get { return longDescription; }
            set
            {
                longDescription = value;
                OnPropertyChanged();
            }
        }

        private string documentUploadText;

        public string DocumentUploadText
        {
            get { return documentUploadText; }
            set
            {
                documentUploadText = value;
                OnPropertyChanged();
            }
        }

        private double numPoints;

        public double NumPoints
        {
            set
            {
                numPoints = value;
                OnPropertyChanged();
            }
        }

        public Action DisplayEmptyFieldPrompt;

        public ICommand SubmitCommand { protected set; get; }

        private void RequiredFieldsFilled()
        {
            bool postGradCheck = true;
            if (documentUploadText == "No document selected.")
            {
                documentUploadText = null;
            }

            if (SelectedCatagory == "Post Graduate Studies" && DocumentUploadText == null)
            {
                postGradCheck = false;
            }

            //Upload to Local Database
            if (SelectedCatagory != null && SelectedSubCatagory != null && shortDescription != null &&
                (dateCompleted != null && dateCompleted <= DateTime.Now) && quantity > 0 && postGradCheck)
            {
                if (key != null)
                {
                    db.InsertOrUpdateActivity(new ActivityModel()
                    {
                        Id = (int) key,
                        UserId = (int) db.GetCurrentUserId(),
                        Catagory = SelectedCatagory,
                        SubCatagory = SelectedSubCatagory,
                        ShortDescription = shortDescription,
                        DateCompleted = dateCompleted.Date,
                        FurtherDetails = furtherDetails,
                        Quantity = quantity,
                        LongDescription = longDescription,
                        SupportingDocument = documentUploadText,
                        NumPoints = numPoints * quantity
                    });
                }
                else
                {
                    db.InsertActivity(new ActivityModel()
                    {
                        UserId = (int) db.GetCurrentUserId(),
                        Catagory = SelectedCatagory,
                        SubCatagory = SelectedSubCatagory,
                        ShortDescription = shortDescription,
                        DateCompleted = dateCompleted.Date,
                        FurtherDetails = furtherDetails,
                        Quantity = quantity,
                        LongDescription = longDescription,
                        SupportingDocument = documentUploadText,
                        NumPoints = numPoints * quantity
                    });
                }

                NavigationService.Instance.PopAsync();
            }
            else
            {
                DisplayEmptyFieldPrompt();
            }
        }

        private static Dictionary<string, Dictionary<string, Tuple<Tuple<string, string>, double>>> CatagoryList;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> EmploymentSubCatagory;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> SIRTSubCatatgory;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> AttendanceAtScientificMeetings;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> PresentationAtMeetings;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> Publications;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> WashingtonUniversityOnline;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> StructuredReading;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> PostGraduateStudies;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> ProfessionalService;

        private static Dictionary<string, Tuple<Tuple<string, string>, double>> OtherActivities;
    }
}