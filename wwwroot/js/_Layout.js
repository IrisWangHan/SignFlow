var navbar = document.querySelector('#navbarContainer');
var navmenu = document.querySelector('#navContainer');
var main = document.querySelector('#mainContainer');
navbar.addEventListener('click', function () {
    console.log('dd');
    if (navmenu.style.display === 'flex') {
        navmenu.style.display = 'none';

    } else {
        navmenu.style.display = 'flex';
    }
    // // 檢查螢幕寬度
    // if (window.innerWidth < 768) {
    //     // 切換選單顯示狀態
    //     if (navmenu.classList.contains('nav-show')) {
    //         navmenu.classList.remove('nav-show'); // 隱藏選單
    //         navmenu.classList.add('nav-hide');
    //         main.style.display = 'block'; // 顯示主要內容
    //     } else {
    //         navmenu.classList.add('nav-show'); // 顯示選單
    //         navmenu.classList.remove('nav-hide');
    //         main.style.display = 'none'; // 隱藏主要內容
    //     }
    // }
    // else {
    //     // 大於等於 768px，切換隱藏狀態
    //     if (navmenu.classList.contains('nav-show') || navmenu.style.display === 'flex') {
    //         navmenu.style.display = 'none';

    //     } else {
    //         navmenu.style.display = 'flex';
    //     }
    // }
    // navmenu.classList.toggle('nav-hide');
    console.log(navmenu);

})