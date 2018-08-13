using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SchedulingView : System.Web.UI.Page
{

    Scheduler ObjSch = new Scheduler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind the Scheduling 
            grdschedule.DataSource = ObjSch.DoScheduling();
            grdschedule.DataBind();

        }
    }


}