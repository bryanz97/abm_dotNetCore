using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using mvc_test.Models;  
  
namespace mvc_test.Controllers  
{  
    public class ClientController : Controller  
    {  
        EmployeeDataAccessLayer dataAccess = new EmployeeDataAccessLayer();  
    
        public IActionResult Index()  
        {  
            List<Clientes> lstCliente = new List<Clientes>();  
            lstCliente = dataAccess.GetAllClientes().ToList();  
  
            return View(lstCliente);  
        }
        
        #region Create()
        [HttpGet]  
        public IActionResult Create()  
        {  
             return View();  
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create([Bind] Clientes client)  
        {  
            if (ModelState.IsValid)  
            {  
                dataAccess.AddClientes(client);  
                return RedirectToAction("Index");  
            }  
            return View(client);  
        }
        #endregion
        
        #region Edit()

        [HttpGet]    
        public IActionResult Edit(int? id)    
        {    
        if (id == null)    
        {    
            return NotFound();    
        }    
        Clientes client = dataAccess.GetClientData(id);    

        if (client == null)    
        {    
            return NotFound();    
        }    
        return View(client);    
        }    

        [HttpPost]    
        [ValidateAntiForgeryToken]    
        public IActionResult Edit(int id, [Bind]Clientes client)    
        {    
        if (id != client.ID)    
        {    
            return NotFound();    
        }    
        if (ModelState.IsValid)    
        {    
            dataAccess.UpdateClientes(client);    
            return RedirectToAction("Index");    
        }    
        return View(client);    
        } 
        #endregion
     
        #region Details()
        [HttpGet]  
        public IActionResult Details(int? id)  
        {  
            if (id == null)  
            {  
                return NotFound();  
            }  
            Clientes client = dataAccess.GetClientData(id);  
  
            if (client == null)  
            {  
                return NotFound();  
            }  
            return View(client);  
        }          
        #endregion
    
        #region  Delete()
        [HttpGet]  
        public IActionResult Delete(int? id)  
        {  
            if (id == null)  
            {  
                return NotFound();  
            }  
            Clientes client = dataAccess.GetClientData(id);  
        
            if (client == null)  
            {  
                return NotFound();  
            }  
            return View(client);  
        }  
        
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]  
        public IActionResult DeleteConfirmed(int? id)  
        {  
            dataAccess.DeleteCliente(id);  
            return RedirectToAction("Index");  
        }      
        #endregion
    }
}
    
        
    