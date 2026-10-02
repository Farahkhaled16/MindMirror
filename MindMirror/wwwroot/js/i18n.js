// t('English text', 'النص العربي') returns the text for the current page language
window.t = function (en, ar) {
    return document.documentElement.lang === 'ar' ? ar : en;
};