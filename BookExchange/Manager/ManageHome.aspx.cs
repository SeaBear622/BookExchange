﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookExchangeModel;

public partial class Managing_Home : System.Web.UI.Page
{
    int _id = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["type"] == null || Session["type"] == "0")
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {            
            using (BookExchangeEntities myEntity = new BookExchangeEntities())
            {
                // load all home
                var allHome = from h in myEntity.Homes
                              orderby h.EnteredOn descending
                              select new { h.MessageOne, h.MessageTwo, h.MessageThree, h.ImageURLOne, h.ImageURLTwo, h.ImageURLThree, h.EnteredOn };

                Repeater1.DataSource = allHome.Take(5);
                Repeater1.DataBind();

                // if update
                if (!IsPostBack)
                {
                    var home = (from h in myEntity.Homes
                                orderby h.EnteredOn descending
                                select h).FirstOrDefault();
                   
                    if (home != null)
                    {
                        txtMessageOne.Text = home.MessageOne;
                        txtMessageTwo.Text = home.MessageTwo;
                        txtMessageThree.Text = home.MessageThree;
                        btnUpdate.Text = "Update";
                        _id = home.Id;
                    }
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        using (BookExchangeEntities myEntity = new BookExchangeEntities())
        {
            var home = (from h in myEntity.Homes
                        orderby h.EnteredOn descending
                        select h).FirstOrDefault();

            Home myHome;

            // if insert
            if (_id == -1)
            {
                myHome = new Home();
                myHome.EnteredOn = DateTime.Now;

                myEntity.AddToHomes(myHome);
            }
            else
            {
                myHome = (from p in myEntity.Homes
                          where p.Id == _id
                          select p).SingleOrDefault();
            }

            myHome.MessageOne = txtMessageOne.Text;
            myHome.MessageTwo = txtMessageTwo.Text;
            myHome.MessageThree = txtMessageThree.Text;
            // default is previous image
            if (home != null)
            {
                myHome.ImageURLOne = home.ImageURLOne;
                myHome.ImageURLTwo = home.ImageURLTwo;
                myHome.ImageURLThree = home.ImageURLThree;
            }
            // Image one
            if (FileUpload1.HasFile)
            {
                string virtualFolder = "~/Images/Home/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileUpload1.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));
                myHome.ImageURLOne = virtualFolder + fileName + extension;
            }

            // Image two
            if (FileUpload2.HasFile)
            {
                string virtualFolder = "~/Images/Home/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUpload2.FileName);
                FileUpload2.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));
                myHome.ImageURLTwo = virtualFolder + fileName + extension;
            }

            // Image three
            if (FileUpload3.HasFile)
            {
                string virtualFolder = "~/Images/Home/";
                string physicalFolder = Server.MapPath(virtualFolder);
                string fileName = Guid.NewGuid().ToString();
                string extension = System.IO.Path.GetExtension(FileUpload3.FileName);
                FileUpload3.SaveAs(System.IO.Path.Combine(physicalFolder, fileName + extension));
                myHome.ImageURLThree = virtualFolder + fileName + extension;
            }            
            myEntity.SaveChanges();
            // Response.Redirect("~/Manager/Default.aspx");
        }
    }
}