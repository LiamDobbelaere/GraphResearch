using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GraphResearch.Graphs
{
    public class GraphDisplay
    {
        private static string HTML_TEMPLATE = @"
            <html>
            <head>
	            <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.css'/>
            </head>
            <body>	
	            <div id='network'></div>
	            <script src='https://cdnjs.cloudflare.com/ajax/libs/vis/4.21.0/vis.min.js'></script>
	            <script>
	              // create an array with nodes
	              var nodes = new vis.DataSet([
                    %NODES%
	              ]);

	              // create an array with edges
	              var edges = new vis.DataSet([
                    %EDGES%
	              ]);

	              // create a network
	              var container = document.getElementById('network');
	              var data = {
		            nodes: nodes,
		            edges: edges
	              };
	              var options = {
	                nodes: {
                        shape: 'circle',
                        size: 13,
                        font: {
                            size: 12,
				            color: 'white',
				            strokeColor: 'black',
				            strokeWidth: 3
			            },
                        shadow:true
                    },
                    edges: {
                        width: 2,
			            font: {
				            size: 10,
				            color: 'white',
				            strokeColor: 'black',
				            strokeWidth: 2
			            },
			            arrows: 'to',
                        shadow:true
                    }
	              };
	              var network = new vis.Network(container, data, options);
	            </script>
            </body>
            </html>
        ";

        public static void Display(Graph g)
        {
            string nodes = "";
            MD5 md5 = MD5.Create();

            foreach (Vertex v in g.Vertices.Values)
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(v.Name));
                Color color = Color.FromArgb(hash[0], hash[1], hash[2]);
                String hexColor = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                nodes += String.Format("{{id: '{0}', label: '{0}', color: '{1}'}},\r\n", v.Name, hexColor);
            }

            nodes = nodes.Substring(0, nodes.Length - 3) + "\r\n";
            string edges = "";

            foreach (Vertex v in g.Vertices.Values)
            {
                foreach (Edge e in v.Connections)
                {
                    edges += String.Format("{{from: '{0}', to: '{1}', label: '{2}'}},\r\n", v.Name, e.Next.Name, e.Type.ToString().ToLower().Replace('_', ' '));
                }
            }

            edges = edges.Substring(0, edges.Length - 3) + "\r\n";

            string output = HTML_TEMPLATE;
            output = output.Replace("%NODES%", nodes);
            output = output.Replace("%EDGES%", edges);

            File.WriteAllText("temp.html", output);
            ProcessStartInfo info = new ProcessStartInfo(Path.GetFullPath("temp.html"));
            info.UseShellExecute = true;

            Process.Start(info);
        }
    }
}
