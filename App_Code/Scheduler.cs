using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Make schedule for the next two week for the Employees 
/// </summary>
public class Scheduler
{
   
    public Scheduler()
    {
        //
        // TODO: Add constructor logic here
        //
    

    }
    /// <summary>
    /// Create a data table to hold the employee details 
    /// and morning and afternoon shifts 
    /// </summary>   
    public DataTable GetEmployeeScheduleTable()
    {

        DataTable dtEmployeeSchedule = new DataTable();
        dtEmployeeSchedule.Clear();
        dtEmployeeSchedule.Columns.Add("EmployeeName");
        dtEmployeeSchedule.Columns.Add("MorningShift");
        dtEmployeeSchedule.Columns.Add("AfternoonShift");        
        return dtEmployeeSchedule;
    }
    /// <summary>
    /// Create data table to hold the scheduling details for the next two weeks     
    /// </summary>   
    public DataTable GetScheduledListTable()
    {

        DataTable dtEmployeeSchedule = new DataTable();
        dtEmployeeSchedule.Clear();
        dtEmployeeSchedule.Columns.Add("WorkingDate");
        dtEmployeeSchedule.Columns.Add("MorningShiftEmloyee");
        dtEmployeeSchedule.Columns.Add("AfternoonShiftEmployee");
        return dtEmployeeSchedule;
    }
    /// <summary>
    /// Save 10 employees details to DtEmployeeSchedule
    /// </summary>   
    /// <param name="DtEmployeeSchedule">a datatable,
    /// for saving the employee details to that datatable
    ///</param>
    public DataTable AddEmployeesToTable(DataTable DtEmployeeSchedule)
    {
        DataRow NewEmployeesRowOne = DtEmployeeSchedule.NewRow();
        NewEmployeesRowOne["EmployeeName"] = "Employee A";
        NewEmployeesRowOne["MorningShift"] = "0";
        NewEmployeesRowOne["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowOne);

        DataRow NewEmployeesRowTwo = DtEmployeeSchedule.NewRow();
        NewEmployeesRowTwo["EmployeeName"] = "Employee B";
        NewEmployeesRowTwo["MorningShift"] = "0";
        NewEmployeesRowTwo["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowTwo);

        DataRow NewEmployeesRowThree = DtEmployeeSchedule.NewRow();
        NewEmployeesRowThree["EmployeeName"] = "Employee C";
        NewEmployeesRowThree["MorningShift"] = "0";
        NewEmployeesRowThree["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowThree);

        DataRow NewEmployeesRowFour = DtEmployeeSchedule.NewRow();
        NewEmployeesRowFour["EmployeeName"] = "Employee D";
        NewEmployeesRowFour["MorningShift"] = "0";
        NewEmployeesRowFour["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowFour);

        DataRow NewEmployeesRowFive = DtEmployeeSchedule.NewRow();
        NewEmployeesRowFive["EmployeeName"] = "Employee E";
        NewEmployeesRowFive["MorningShift"] = "0";
        NewEmployeesRowFive["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowFive);

        DataRow NewEmployeesRowSix = DtEmployeeSchedule.NewRow();
        NewEmployeesRowSix["EmployeeName"] = "Employee F";
        NewEmployeesRowSix["MorningShift"] = "0";
        NewEmployeesRowSix["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowSix);

        DataRow NewEmployeesRowSeven = DtEmployeeSchedule.NewRow();
        NewEmployeesRowSeven["EmployeeName"] = "Employee G";
        NewEmployeesRowSeven["MorningShift"] = "0";
        NewEmployeesRowSeven["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowSeven);

        DataRow NewEmployeesRowEight = DtEmployeeSchedule.NewRow();
        NewEmployeesRowEight["EmployeeName"] = "Employee H";
        NewEmployeesRowEight["MorningShift"] = "0";
        NewEmployeesRowEight["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowEight);

        DataRow NewEmployeesRowNine = DtEmployeeSchedule.NewRow();
        NewEmployeesRowNine["EmployeeName"] = "Employee I";
        NewEmployeesRowNine["MorningShift"] = "0";
        NewEmployeesRowNine["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowNine);

        DataRow NewEmployeesRowTen = DtEmployeeSchedule.NewRow();
        NewEmployeesRowTen["EmployeeName"] = "Employee J";
        NewEmployeesRowTen["MorningShift"] = "0";
        NewEmployeesRowTen["AfternoonShift"] = "0";
        DtEmployeeSchedule.Rows.Add(NewEmployeesRowTen);
        return DtEmployeeSchedule;
    }

    /// <summary>
    /// Schedule the employees to next two weeks for the morning and afternoon shifts 
    /// </summary>   

    public DataTable DoScheduling()
    {

        DataTable DtAllEmployeeListForSheduling = AddEmployeesToTable(GetEmployeeScheduleTable());
        DateTime FirstWorkingDayOfCurrentWeek = GetFirstWorkingDayofCurrentWeek();
        DateTime LastWorkingDayOfSecondWeek = GetLastWorkingDayOfSecondWeek(FirstWorkingDayOfCurrentWeek);
        DataTable GetSheduledListEmployee = GetScheduledListTable();
        // Loop Through all the dates in two weeks
        foreach (DateTime day in EachDay(FirstWorkingDayOfCurrentWeek, LastWorkingDayOfSecondWeek))
        {

            DataRow NewSheduledRow = GetSheduledListEmployee.NewRow();
            NewSheduledRow["WorkingDate"] = day.ToShortDateString();
            // Check the day is a holyday
            if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
            {
                //Morning Shift Assignments 
                for (int MorningShift = 0; MorningShift < DtAllEmployeeListForSheduling.Rows.Count; MorningShift++)
                {
                    if (DtAllEmployeeListForSheduling.Rows[MorningShift]["MorningShift"].ToString() == "0")
                    {
                        NewSheduledRow["MorningShiftEmloyee"] = DtAllEmployeeListForSheduling.Rows[MorningShift]["EmployeeName"].ToString();
                    }
                    if (NewSheduledRow["MorningShiftEmloyee"].ToString() != string.Empty)
                    {
                        DtAllEmployeeListForSheduling.Rows[MorningShift]["MorningShift"] = "1";

                        break;
                    }
                }
                //Afternoon Shift Assignments
                for (int AfternoonShift = 0; AfternoonShift < DtAllEmployeeListForSheduling.Rows.Count; AfternoonShift++)
                {

                    if (DtAllEmployeeListForSheduling.Rows[AfternoonShift]["AfternoonShift"].ToString() == "0")
                    {
                        if (NewSheduledRow["MorningShiftEmloyee"].ToString() != DtAllEmployeeListForSheduling.Rows[AfternoonShift]["EmployeeName"].ToString())
                        {
                            NewSheduledRow["AfternoonShiftEmployee"] = DtAllEmployeeListForSheduling.Rows[AfternoonShift]["EmployeeName"].ToString();

                        }
                    }
                    if (NewSheduledRow["AfternoonShiftEmployee"].ToString() != string.Empty)
                    {
                        DtAllEmployeeListForSheduling.Rows[AfternoonShift]["AfternoonShift"] = "1";
                        break;
                    }
                }

                GetSheduledListEmployee.Rows.Add(NewSheduledRow);

            }
            else
            {
               //The day is a holyday
                NewSheduledRow["MorningShiftEmloyee"]="Holyday";
                NewSheduledRow["AfternoonShiftEmployee"] = "Holyday";
                GetSheduledListEmployee.Rows.Add(NewSheduledRow);
            }



        }

        return GetSheduledListEmployee;
    }
    /// <summary>
    /// Get all the dates in between from and to Dates
    /// </summary>   
    /// <param name="from"> Start Date </param>
    /// <param name="thru"> End Date </param>
    public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }

    /// <summary>
    /// Get First Working Day of Current Week
    /// </summary>   
   
    public DateTime GetFirstWorkingDayofCurrentWeek()
    {
        DateTime CurrentDate = DateTime.Now;
        DateTime FirstWorkingDayOfCurrentWeek;
        DayOfWeek startOfWeek = DayOfWeek.Monday;
        int diff = (7 + (CurrentDate.DayOfWeek - startOfWeek)) % 7;
        FirstWorkingDayOfCurrentWeek = CurrentDate.AddDays(-1 * diff).Date;
        return FirstWorkingDayOfCurrentWeek;
    }
    /// <summary>
    ///  Get Last working day of next week using the first working day of current week 
    /// </summary>  
    /// <param name="FirstWorkingDayofCurrentWeek">first working day of current week</param>  
   
    public DateTime GetLastWorkingDayOfSecondWeek(DateTime FirstWorkingDayofCurrentWeek)
    {
        return FirstWorkingDayofCurrentWeek.AddDays(11);
    }


   

   

}