let editIcon = $('#userTable2 .editRow .editIcon');

// hide row data if there's no inputs shown
editIcon.click(function (e) { 
    e.preventDefault();
    if (!editIcon.hasClass('d-none')) {
        $(e.delegateTarget.offsetParent.children).addClass('d-none');
        getInput(e);
    }
});

// display input to edit data
function getInput(e){
    $(e.currentTarget.parentElement).append(`
        <div class="d-flex justify-content-center align-items-center editData">
            <input type="number" class="form-control w-50 d-inline-block editInput">
            <button class="btn btn-secondary p-1 d-inline-block ml-1 editBtn">edit</button>
            <small class='d-none text-danger ml-2 alertError'>Invalid number </small>
        </div>
    `);
    enterNewValue();
}

// hide input & button and display new value after validate
function enterNewValue() { 
    let editBtn = $('#userTable2 .editRow .editData .editBtn');
    
    editBtn.click(function (e) { 
        e.preventDefault();
        let inputValue = e.delegateTarget.offsetParent.children[2].children[0].value;
        
        if (inputValue >= 0 && inputValue != ""){
        $(e.delegateTarget.offsetParent.children).removeClass('d-none');
        $(e.delegateTarget.offsetParent.children[0].children)[0].innerText = inputValue
        e.delegateTarget.offsetParent.children[2].remove()
        }else{
            $(e.delegateTarget.offsetParent.children[2].children[2]).removeClass('d-none');
        }
    });
 }





