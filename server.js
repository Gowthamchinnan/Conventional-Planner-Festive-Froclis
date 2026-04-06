const express = require('express');
const path = require('path');
const app = express();
const PORT = 5000;

// Serve static files
app.use(express.static(path.join(__dirname, 'public')));

// IMPORTANT: This is a placeholder server for development only.
// This server serves static assets (.css, .js, .html) but CANNOT execute ASP.NET (.aspx) files.
// For full functionality with database operations, you still need IIS Express or Visual Studio.

// Redirect root to Homepage
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'Homepage.aspx'));
});

// Catch-all for .aspx files (will show as static content, not executed)
app.use((req, res, next) => {
    console.log(`Request: ${req.path}`);
    if (req.path.endsWith('.aspx')) {
        res.status(501).send(`
            <html>
            <head>
                <title>ASP.NET Required</title>
                <style>
                    body { font-family: Arial; margin: 40px; }
                    .warning { background: #fff3cd; padding: 20px; border: 1px solid #ffc107; border-radius: 4px; }
                </style>
            </head>
            <body>
                <div class="warning">
                    <h2>⚠️ ASP.NET Server Not Available</h2>
                    <p>This Node.js development server cannot execute ASP.NET files (.aspx).</p>
                    <p><strong>To run this application fully, you need:</strong></p>
                    <ul>
                        <li><strong>IIS Express</strong> (download from: https://www.microsoft.com/en-us/download/details.aspx?id=48264)</li>
                        <li><strong>OR Visual Studio</strong> (which includes IIS Express)</li>
                        <li>SQL Server Express for database features</li>
                    </ul>
                    <p><strong>Requested file:</strong> ${req.path}</p>
                </div>
            </body>
            </html>
        `);
    } else {
        next();
    }
});

app.listen(PORT, () => {
    console.log(`
╔════════════════════════════════════════════════════════════╗
║  Conventional Festive Frolics - Development Server         ║
║  ⚠️  LIMITED MODE - ASP.NET Not Supported                  ║
╚════════════════════════════════════════════════════════════╝

Server running at:  http://localhost:${PORT}/
Static files only:  CSS, JavaScript, Images

To run ASP.NET code, install IIS Express:
https://www.microsoft.com/en-us/download/details.aspx?id=48264
    `);
});
