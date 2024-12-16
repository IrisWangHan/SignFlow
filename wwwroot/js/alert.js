


function alertBox(content) {
    const showAlertBox = document.createElement("div");
    showAlertBox.id = "showAlert";
    showAlertBox.style.position = "fixed";
    showAlertBox.style.top = "50%";
    showAlertBox.style.left = "50%";
    showAlertBox.style.transform = "translate(-50%, -50%)";
    showAlertBox.style.zIndex = "1050"; // 確保顯示在頁面最上層
    showAlertBox.style.width = "440px"; // 設定容器寬度
    showAlertBox.style.height = "auto"; // 設定容器高度
    showAlertBox.style.backgroundColor = "#d2e4f5";
    showAlertBox.style.display = "flex";
    showAlertBox.style.justifyContent = "center";
    showAlertBox.style.alignItems = "center";
    showAlertBox.style.paddingTop = "45px";
    showAlertBox.style.borderRadius = "5px";
    // const showAlertBox = document.createElement("div");
    // showAlertBox.id = "showAlert";
    // 動態創建 Alert
    const alertDiv = document.createElement("div");
    alertDiv.className = "alert alert-light fade show";
    alertDiv.role = "alert";
    alertDiv.id = "showAlert";

    // 動態創建 Alert 標題
    const alertTitle = document.createElement("div");
    alertTitle.className = "showAlert-title";
    alertTitle.innerText = "提示訊息";

    // 動態創建 Alert 內容
    const alertContent = document.createElement("span");
    alertContent.innerText = content;

    // 動態創建關閉按鈕
    const closeButton = document.createElement("button");
    closeButton.type = "button";
    closeButton.className = "btn-close showAlert-close"; // 使用 Bootstrap 樣式
    closeButton.setAttribute("data-bs-dismiss", "alert");
    closeButton.setAttribute("aria-label", "Close");

    // 將 Alert 的元素組合起來

    alertDiv.appendChild(alertTitle);
    alertDiv.appendChild(alertContent);
    alertDiv.appendChild(closeButton);
    showAlertBox.appendChild(alertDiv);
    // 將 Alert 插入到 body 中
    document.body.appendChild(showAlertBox);

    // 當關閉按鈕被點擊時，關閉 Alert
    // closeAlertBox();
    // 監聽關閉按鈕點擊事件
    closeButton.addEventListener('click', function () {
        // 隱藏整個 alertBox
        showAlertBox.style.display = 'none';
    });

}
