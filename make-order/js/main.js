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
