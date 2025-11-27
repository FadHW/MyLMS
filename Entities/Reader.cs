using MyLMS.Services;

namespace MyLMS.Entities;

public class Reader: Members
        {
            private int _Borrowedbooks = 0;
            private bool _HasOutStandingFees;
            public DateTime MembershipExpiry { get; set; }      
            public Reader(int id, string name, string email, DateTime x) : base(id, name, email)
            {
                _HasOutStandingFees = false;
                MembershipExpiry = x;
            }
         
            public void RenewMembership(bool Payed)
            {
                if (Payed == true)
                {
                    _HasOutStandingFees = false;
                    MembershipExpiry=DateTime.Now.AddYears(1);
                }
                else
                {
                    _HasOutStandingFees = true;
                }
            }
            public void ReaderBorrowCounter()
            {
                ++_Borrowedbooks;
            }
            public bool BlockedReader()
            {
                if (_HasOutStandingFees == true || _Borrowedbooks >= 6 || !IsMembershipActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void ReaderReturnCounter()
            {
                if (_Borrowedbooks > 0)
                {
                    _Borrowedbooks -= 1;
                }
            }
            public bool IsMembershipActive => DateTime.Now <= MembershipExpiry;
            public int CurrentBorrowedBooks()
            {
                return _Borrowedbooks;
            }
            public void CheckNotifications()
            {
                if ((MembershipExpiry - DateTime.Now).TotalDays <= 7 && IsMembershipActive)
                {
                    Console.WriteLine($"Alert: Your membership will expire in {(MembershipExpiry - DateTime.Now).Days} days.");
                }

                if (_Borrowedbooks >= LibraryServices.MaxBooks - 1)
                {
                    Console.WriteLine($"Alert: You are approaching the maximum number of borrowed books ({LibraryServices.MaxBooks}).");
                }
            }
            private void CheckBorrowLimit()
            {
                if (_Borrowedbooks > LibraryServices.MaxBooks)
                {
                    Console.WriteLine("Warning! U have hit the maximum number of books");
                }
            }
        }
}
