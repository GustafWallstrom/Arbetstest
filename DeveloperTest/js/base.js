(function () {

  'use strict';

  const apiUrl = '/api/logservice/';

  /**
   * @param {string} method 
   * @param {object} param 
   * @returns {Promise<T>}
   * @template T
   */
  function request(method, param = {}) {
    return new Promise((resolve, reject) => {
      ar(apiUrl + method, param, resolve, reject);
    });
  }

  /**
   * @param {Function} func 
   * @param {number} wait 
   * @param {boolean} immediate 
   */
  function debounce(func, wait, immediate = false) {
    let timeout;

    const res = function () {
      let that = this;
      let args = [];

      for (let i = 0; i < arguments.length; i++) {
        args.push(arguments[i]);
      }

      const later = () => {
        timeout = 0;
        if (!immediate) {
          func.apply(that, args);
        }
      };

      let callNow = immediate && !timeout;

      clearTimeout(timeout);
      timeout = setTimeout(later, wait);

      if (callNow) {
        func.apply(that, args);
      }
    };

    return res;
  }

  window.helper = {
    request,
    debounce,

    logService: {

      /**
       * @param {number} id 
       */
      get(id) {
        return request('Get', { id });
      },

      /**
       * @param {number} id 
       */
      delete(id) {
        return request('Delete', { id });
      },

      /**
       * @param {string} text 
       */
      search(text) {
        return request('Search', { text });
      }
    }
  };

  const checkValue = el => el.toggleClass('hasvalue', el.val().length !== 0);

  $('.pageform input[type=text], .pageform input[type=password], .pageform textarea').change(function () {
    checkValue($(this));
  }).each(function () {
    checkValue($(this));
  });

  if (window.fd) {
    window.fd('base.js');
  }

}());
