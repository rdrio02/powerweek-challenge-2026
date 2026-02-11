using System;
using System.IO;
using System.IO.Compression;

if (args.Length < 2)
{
    Console.Error.WriteLine("Usage: brotli <input.br> <output>");
    return 1;
}

var inputPath = args[0];
var outputPath = args[1];

using var input = File.OpenRead(inputPath);
using var output = File.Create(outputPath);
using var brotli = new BrotliStream(input, CompressionMode.Decompress);

brotli.CopyTo(output);
return 0;
