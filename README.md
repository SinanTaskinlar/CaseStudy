# CaseStudy

Generator

POST:/generator  methoduna gönderilen URL, uzunluğu maksimum 6 karakter olan yeni bir kısaltılmış link döndürür. 

Dispatch

POST:/dispatch  methoduna gönderilen kısaltılmış URL'in, orjinal halini döndürür.


Örnek istekler: 

Generate:  

  http://localhost:29539/Url/Generate/

Body: 
  {
	  "Long":"http://teamdefinex.com/sinantaskinlar123"
  }


Dispatch:

  http://localhost:29539/Url/Dispatch/

Body:
  {
	  "Short":"http://dfx.com/RKwKAA"
  }
