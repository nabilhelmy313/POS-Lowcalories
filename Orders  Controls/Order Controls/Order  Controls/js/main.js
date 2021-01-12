// add meals
    let buyMeal = document.querySelectorAll(".meal-img .buyNow");
    let mealPrice = document.querySelectorAll('.meal-img .overlay b span');
    let mealName = document.querySelectorAll('.meal-img .overlay h4');
    
    for (let i = 0; i < buyMeal.length; i++) {
          buyMeal[i].addEventListener('click',()=>{
                  $('#meals').prepend(`
                        <div class="order-number overflow-auto my-4">
                        <div class="order-name float-left d-flex justify-content-center align-items-center">
                            <i class="far fa-trash-alt text-gradient pointer" onclick='deleteOrder(event)'></i>
                          <div class="ml-2">
                          <h6 class="m-0" style="font-size: 14px;">${mealName[i].innerText}</h6>
                          <small class="text-muted">${mealPrice[i].innerText}</small>
                          </div>
                        </div>
                        <div class="counter float-right d-flex justify-content-center align-items-center">
                          <div class="num">1</div>
                          <div class="counterBtn">
                              <button class="btn bg-gradient text-white d-block py-0 px-2 counterUp" onclick='getCounterUp(event)'>
                                  <i class="fas fa-angle-up"></i>
                              </button>
                              <button class="btn bg-gradient text-white d-block py-0 px-2 counterDown" onclick='getCounterDown(event)'>
                                  <i class="fas fa-angle-down"></i>
                              </button>
                          </div> 
                        </div>
                        <div class="clearfix"></div>
                        <small class="float-right mr-1 numberOfMeals">Total ${mealPrice[i].innerText} AED</small>
                     </div>
                  `);
                  $('#meals').height('200px');
          })
      }

// Counter Up
function getCounterUp (event) {

  event.preventDefault();
  let buttonUp = document.querySelectorAll(".counterUp");
  let countUp = 1;

  if (event.composedPath()[3].className == "counter float-right d-flex justify-content-center align-items-center") {
      countUp = Number(event.composedPath()[3].children[0].innerText) + 1;
      event.composedPath()[3].children[0].innerText = countUp;
      event.composedPath()[4].children[3].innerText = "Total "+ countUp*event.composedPath()[4].children[0].children[1].children[1].innerText +" AED";
  } else{
      countUp = Number(event.composedPath()[2].children[0].innerText) + 1;
      event.composedPath()[2].children[0].innerText = countUp;
      event.composedPath()[3].children[3].innerText = "Total "+countUp*event.composedPath()[3].children[0].children[1].children[1].innerText +" AED";
  }

  for (let i = 0; i < buttonUp.length; i++) {
      $(buttonUp[i]).css({'box-shadow':"none",'outline':"0"});
    }
        
}

// Counter Down
function getCounterDown (event) {

  event.preventDefault();
   let buttonDown = document.querySelectorAll(".counterDown");
   let countDown = 1;

if (event.composedPath()[3].className == "counter float-right d-flex justify-content-center align-items-center") {

    if (event.composedPath()[3].children[0].innerText > 1) {
      countDown = Number(event.composedPath()[3].children[0].innerText) - 1;
      event.composedPath()[3].children[0].innerText = countDown;
      event.composedPath()[4].children[3].innerText = "Total "+ countDown*event.composedPath()[4].children[0].children[1].children[1].innerText+" AED";
    }
 } else{
    if (event.composedPath()[2].children[0].innerText > 1) {
      countDown = Number(event.composedPath()[2].children[0].innerText) - 1;
      event.composedPath()[2].children[0].innerText = countDown;
      event.composedPath()[3].children[3].innerText = "Total "+ countDown*event.composedPath()[3].children[0].children[1].children[1].innerText+" AED";
    }  
  }

    for (let i = 0; i < buttonDown.length; i++) {
        $(buttonDown[i]).css({'box-shadow':"none",'outline':"0"});
      }
}
    



// delete order
 function deleteOrder (event) {
     event.composedPath()[2].remove();
   }
 
// media query add and remove elements
let mediaQuery_Max767 = window.matchMedia("(max-width: 767px)") // small screen less than 767

if (window.innerWidth  <= 767) {
    $('#categories').remove();
    $(`
    <div class="row no-gutters" id="categories">
    <div class="col-sm-3 col-6 text-center">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-glass-martini-alt py-2 fa-2x"></i>
        <br>  DRINKS
      </button>
    </div>
    <div class="col-sm-3 col-6 text-center">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-birthday-cake py-2 fa-2x"></i>
        <br>  SWEETS
      </button>
    </div>
    <div class="col-sm-3 col-6 text-center">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-hamburger py-2 fa-2x"></i>
        <br>  MEALS
      </button>
    </div>
    <div class="col-sm-3 col-6 text-center">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-apple-alt py-2 fa-2x"></i>
        <br>  FRUITS
      </button>
    </div>
  </div>
      `).insertAfter('#searchSection');
}
else {
    $('#categories').remove();
    $(`
    <div class="row no-gutters" id="categories">
    <div class="col-12">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-glass-martini-alt py-2 fa-2x"></i>
        <br>  DRINKS
      </button>
    </div>
    <div class="col-12">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-birthday-cake py-2 fa-2x"></i>
        <br>  SWEETS
      </button>
    </div>
    <div class="col-12">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-hamburger py-2 fa-2x"></i>
        <br>  MEALS
      </button>
    </div>
    <div class="col-12">
      <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
        <i class="fas fa-apple-alt py-2 fa-2x"></i>
        <br>  FRUITS
      </button>
    </div>
  </div>
    `).insertAfter('aside .logo');
}

function moveElement_mediaQuery(mediaQuery_Max767) {
    if (mediaQuery_Max767.matches) { // If media query matches
      $('#categories').remove();
      $(`
      <div class="row no-gutters" id="categories">
      <div class="col-sm-3 col-6 text-center">
        <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
          <i class="fas fa-glass-martini-alt py-2 fa-2x"></i>
          <br>  DRINKS
        </button>
      </div>
      <div class="col-sm-3 col-6 text-center">
        <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
          <i class="fas fa-birthday-cake py-2 fa-2x"></i>
          <br>  SWEETS
        </button>
      </div>
      <div class="col-sm-3 col-6 text-center">
        <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
          <i class="fas fa-hamburger py-2 fa-2x"></i>
          <br>  MEALS
        </button>
      </div>
      <div class="col-sm-3 col-6 text-center">
        <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
          <i class="fas fa-apple-alt py-2 fa-2x"></i>
          <br>  FRUITS
        </button>
      </div>
    </div>
        `).insertAfter('#searchSection');

    } else {
      $('#categories').remove();
        $(`
        <div class="row no-gutters" id="categories">
        <div class="col-12">
          <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
            <i class="fas fa-glass-martini-alt py-2 fa-2x"></i>
            <br>  DRINKS
          </button>
        </div>
        <div class="col-12">
          <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
            <i class="fas fa-birthday-cake py-2 fa-2x"></i>
            <br>  SWEETS
          </button>
        </div>
        <div class="col-12">
          <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
            <i class="fas fa-hamburger py-2 fa-2x"></i>
            <br>  MEALS
          </button>
        </div>
        <div class="col-12">
          <button class="btn aside-btn bg-gradient text-white px-4 py-2 radius my-3 shadow">
            <i class="fas fa-apple-alt py-2 fa-2x"></i>
            <br>  FRUITS
          </button>
        </div>
      </div>
        `).insertAfter('aside .logo');
    }
  }

mediaQuery_Max767.addEventListener('change',moveElement_mediaQuery);

// End make order page



(function ($) {
  "use strict";

  
  /*==================================================================
  [ Validate ]*/
  var input = $('.validate-input .input100');

  $('.validate-form').on('submit',function(){
      var check = true;

      for(var i=0; i<input.length; i++) {
          if(validate(input[i]) == false){
              showValidate(input[i]);
              check=false;
          }
      }

      return check;
  });


  $('.validate-form .input100').each(function(){
      $(this).focus(function(){
         hideValidate(this);
      });
  });

  function validate (input) {
      if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
          if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
              return false;
          }
      }
      else {
          if($(input).val().trim() == ''){
              return false;
          }
      }
  }

  function showValidate(input) {
      var thisAlert = $(input).parent();

      $(thisAlert).addClass('alert-validate');
  }

  function hideValidate(input) {
      var thisAlert = $(input).parent();

      $(thisAlert).removeClass('alert-validate');
  }
  
  

})(jQuery);


// =================================   hold controls page

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

 // notification action

let approveOrder = $('.approveOrder');
let orderNumber;
let countOrders = 0;


// push (Append) order info into notification icon
function AppendOrderInfo() { 
    let orderDate = getOrderDate();
    $('#notificationMenu').append(`
    <a class="dropdown-item text-center" href="#">Order Date </br> ${orderDate}</a>
    <a class="dropdown-item" href="#">Order Number : ${orderNumber}</a>
    <div class="dropdown-divider"></div>
    `);
}

// get number of order
approveOrder.click(function (e) { 
    $('#notification').attr("data-toggle","dropdown");
    orderNumber = e.delegateTarget.parentElement.parentElement.children[0].innerText;
    AppendOrderInfo();
    // set number of orders 
    countOrders = parseInt(countOrders)+parseInt(1);
    $('#ordersNumber').text(countOrders);
});

// get date of order
function getOrderDate() {  
 return new Date(new Date().getTime()).toLocaleString('sv-SE');
}

// =================================  Create Order page

 function loadFile(event) {
     let image = document.getElementById('uploadedImg');
     image.style.display = "inline-block";
     image.src = URL.createObjectURL(event.target.files[0]);
 };


// =================================  Create Customer page

 function loadUserImage(event) {
     let image = document.getElementById('uploadedUserImg');
     image.style.display = "inline-block";
     image.src = URL.createObjectURL(event.target.files[0]);
 };

// ==========================================

$('#successSave').hide();
$(`#saveOrder`).click(()=>{
   $('#successSave').fadeIn(1000);
})

// close save alert
$(`#successSave .card-header i`).click(()=>{
  $('#successSave').hide()
});

// =======================================================
// add new function to calculate total price of meal

$('#netInput').blur(()=>{ 
  let total = Number($('#netInput').val()) + Number($('#taxInput').val()) 
  + Number($('#serviceInput').val());
   $('#discountInput').val(null);
  $('#totalInput').val(total);
});

$('#taxInput').blur(()=>{ 
  let total = Number($('#netInput').val()) + Number($('#taxInput').val()) 
  + Number($('#serviceInput').val());
  $('#discountInput').val(null);
  $('#totalInput').val(total);
});

$('#serviceInput').blur(()=>{ 
  let total = Number($('#netInput').val()) + Number($('#taxInput').val()) 
  + Number($('#serviceInput').val());
  $('#discountInput').val(null);
  $('#totalInput').val(total);
});

$('#discountInput').blur(()=>{
  let total = Number($('#netInput').val()) + Number($('#taxInput').val()) 
  + Number($('#serviceInput').val());
  let afterDiscount = total - Number($('#discountInput').val()/100)*total;
  $('#totalInput').val(afterDiscount);
});