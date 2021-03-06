﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyLibrary.Website.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RentalDate { get; private set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; private set; }

        public BorrowingState State { get; private set; }
        public virtual Book Book { get; set; }
        public virtual ApplicationUser Borrower { get; set; }

        public Borrowing()
        {
            RentalDate = DateTime.Now;
            State = BorrowingState.InProgrees;
        }


        public void SetBorrower(ApplicationUser user)
        {
            if(user == null)
            {
                throw new Exception("User is empty.");
            }
            if (Borrower == user) return;
            Borrower = user;
        }

        public void SetBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Book is empty.");
            }
            if (Book == book) return;
            Book = book;
        }

        public void EndBorrowing()
        {
            EndDate = DateTime.Now;
            State = BorrowingState.Closed;
        }

        public void CancelBorrowing()
        {
            EndDate = DateTime.Now;
            State = BorrowingState.Cancelled;
            Book.IsAvailable();
        }
    }

    public enum BorrowingState
    {
        InProgrees,
        Closed,
        Cancelled
    }
}
