using System;
using System.Net;

namespace DebugConsole
{
    class Listener
    {
        public Listener(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            Console.WriteLine("Creating new HTTP listener.");
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            foreach(string prefix in prefixes)
                listener.Prefixes.Add(prefix);

            try
            {
                listener.Start();
                Console.WriteLine("Listening...");

                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: ", ex.Message, ex.StackTrace);
            }
        }
    }
}
