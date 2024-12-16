
var submit = document.querySelector('#submit-btn');
var account = document.querySelector('#account-input');
var password = document.querySelector('#password-input');
var remember_checkbox = document.querySelector('#remember-checkbox');
var captcha = document.querySelector('#captcha-input');

var loading = document.querySelector('#loading-overlay');

submit.addEventListener('click', function () {

    let listArray = [];
    let resMsg = "";
    listArray.push(account);
    listArray.push(password);
    // 或使用擴展運算符（spread operator）
    // const listArray2 = [...listItems];

    // 現在你可以使用陣列的方法，如 forEach() 或 map()
    // listArray.forEach(item => {
    //     if (valueIsnull(item.value)) {
    //         resMsg = item.placeholder;
    //         console.log(resMsg);
    //         alert(resMsg);
    //         return;
    //     }
    // });
    for (const item of listArray) {
        if (valueIsnull(item.value)) {
            resMsg = item.placeholder;
            console.log(resMsg);
            alert(resMsg);
            return;  //END
        }
    }
    var uri = "Login/checkUser"
    // var data = {

    // }
    fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8' // 更正為 application/json
        },
        body: JSON.stringify({
            '帳號': account.value.trim(),
            '密碼': password.value.trim()

        }) // 發送 JSON 格式的資料
    })
        .then(res => res.json())  // 確保回應為 JSON 格式
        .then(result => {
            if (result.success) {
                console.log(result);
                loading.style.display = "flex";
                setTimeout(() => {
                    loading.style.display = "none";
                    window.location.href = result.redirectUrl;
                }, 2000); // 2秒後隱藏 loading


            } else {
                alert(result.message);  // 登入失敗的訊息
            }
        })
        .catch(error => console.error("錯誤:", error));

    // 有填寫 檢查是否輸入不該有的值
    // 檢查是否輸入script ><
    //檢查密碼是否符合格式 (一個大寫一個小寫英文/加上數字)

});
function valueIsnull(val) {
    if (val.trim() == "") {
        return true;
    }
}
// function number() {

// }

// function allowOnlyAlphaNumeric(input) {
//     return input.replace(/[^a-zA-Z0-9]/g, "");
//     // 只允許英文字母和數字
// }

// 監聽input 如果離開focus但未填寫 那就focus 並且顯示訊息