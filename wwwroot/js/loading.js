function createLoadingOverlay() {
    console.log('createLoadingOverlay');
    // 創建 loading-overlay 元素
    const loadingOverlay = document.createElement('div');
    loadingOverlay.id = 'loading-overlay';

    // 設定 loading-overlay 的 CSS 樣式
    loadingOverlay.style.display = 'flex'; // 確保設置為 flex 顯示
    loadingOverlay.style.position = 'fixed';
    loadingOverlay.style.top = '0';
    loadingOverlay.style.left = '0';
    loadingOverlay.style.width = '100%';
    loadingOverlay.style.height = '100%';
    loadingOverlay.style.backgroundColor = 'rgba(0, 0, 0, 0.5)'; // 半透明黑色背景
    loadingOverlay.style.justifyContent = 'center'; // 水平居中
    loadingOverlay.style.alignItems = 'center'; // 垂直居中
    loadingOverlay.style.zIndex = '1050'; // 確保在其他元素上方

    // 創建 spinner 元素
    const spinner = document.createElement('div');
    spinner.classList.add('spinner-border');
    spinner.setAttribute('role', 'status');

    // 創建 loading 提示文字
    const loadingText = document.createElement('span');
    loadingText.classList.add('visually-hidden');
    loadingText.innerText = 'Loading...';

    // 將 spinner 和 loadingText 加入到 loading-overlay 中
    spinner.appendChild(loadingText);
    loadingOverlay.appendChild(spinner);

    // 將 loading-overlay 加入到 body 中
    document.body.appendChild(loadingOverlay);

    return loadingOverlay;
}



function hideLoadingOverlay() {
    const loadingOverlay = document.getElementById('loading-overlay');
    if (loadingOverlay) {
        loadingOverlay.style.display = 'none'; // 隱藏 loading-overlay
    }
}
