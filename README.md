# loan-assesment

Target Framework: net6.0 <br />
Project Type: .Net Core Web Api

### How to run
<ol>
  <li>Open up the project in Visual Studio and press <code>F5</code> (for Debugging) or <code>Ctrl + F5</code> (for Non-Debugging). A swagger page will open in the browser and will display some endpoints to test.</li>
  <li>Or open up terminal and change to project's root directory then type command: <code>dotnet run</code></li> then press <code>Enter</code>. In the terminal, it displays a localhost with a port it is listening to and use it as base url when testing some endpoints.
</ol> 

<b>End Points:</b>
<ul>
  <li><code>POST: https://localhost:7001/api/Assesment</code></li>
  <li><code>GET: https://localhost:7001/api/ExternalService/ValidateBusinessNumber?businessNumber={businessNumber}</code></li>
</ul>
