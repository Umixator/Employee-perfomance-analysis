const { contains } = require("jquery");

function rolefun(role, departmentId)
{
    var pass_logs = document.querySelectorAll('[id="password"], [id="login"], [id="loginLabel"], [id="passwordLabel"]')
    var supervisor_elements = document.querySelectorAll('[id="supervisorSelect"], [id="supervisorLabel"]')
    var supervisor_options = document.querySelectorAll('[name="1"], [name="2"], [name="3"], [name="4"]')

    /*    role Ids: 1 - admin, 2 - employee, 3 - team lead, 4 - head of department*/

    supervisor_options.forEach(e => e.hidden = true)
    if (document.URL.toString().includes("Update") == false) {
        supervisor_elements.forEach(element => element.value = "")
    }    

    if (role == 2) {
        if (departmentId == document.querySelector('[name="3"]').id) {
            document.querySelector('[name="3"]').hidden = false;
        }
        pass_logs.forEach(element => { element.hidden = true; element.value = ""; })
        supervisor_elements.forEach(element => element.hidden = false)
    } else if (role == 4) {
        supervisor_elements.forEach(element => element.hidden = true)
        pass_logs.forEach(element => element.hidden = false)
    } else if (role == 3) {
        if (departmentId == document.querySelector('[name="4"]').id) {
            document.querySelector('[name="4"]').hidden = false;
        }
        pass_logs.forEach(element => element.hidden = false)
        supervisor_elements.forEach(element => element.hidden = false)
    } else {
        pass_logs.forEach(element => element.hidden = false)
        supervisor_elements.forEach(element => element.hidden = true)
    }
    
}