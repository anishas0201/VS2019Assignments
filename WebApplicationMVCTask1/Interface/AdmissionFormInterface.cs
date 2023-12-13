using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.Interface
{
    interface AdmissionFormInterface
    {
        ResponseModel SaveForm(AdmissionFormData form);
        List<AdmissionFormData> AdmissionList();
        AdmissionFormData GetCollegebyId(int AdmissionId);
        ResponseModel DeleteCollegeDetail(int AdmissionId);
        ResponseModel UpdateCollegeDetail(AdmissionFormData form);


        List<AdmissionFormData> SearchByDate(string fromDate, string toDate);
    }
}
