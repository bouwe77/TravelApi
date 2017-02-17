function handleResponse(status, response) {
   alert(status + " - " + response);
}

function request(method, url) {
   var xhr = new XMLHttpRequest();
   xhr.open(method, url, true);
   xhr.onreadystatechange = function () {
      if (xhr.readyState === XMLHttpRequest.DONE) {
         handleResponse(xhr.status, xhr.responseText);
      }
   };
   xhr.send();
}