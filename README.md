# ohash

```batch
Calculate hash for stdin or a file. A hash is like a signature for data, and
thus is used to distingush different chunks of data (or files). This
distinction can be:

- Space wise, say between 2 different files.
- Time wise, say between the same file some time ago, and now.

The resulting hash value is a number (usually very large) generated from the
input data is designed such that very similar, but different data have
completely different hash values, making them easily distinguishable by eye.
To be clear, these hash values cannot be used to generate / extract the actual
data, and are not useful without it. 

There exist a few popular hash functions (yes, they are very similar to math
functions used in class to generate an output value from multiple input values)
that can be used to generate hash values:

- MD5 (Merkle-Damgård 5) 128-bit hash function by Ronald Rivest.
- RIPEMD160 (RACE Integrity Primitives Evaluation Message Digest) 160-bit hash
  function by Hans Dobbertin, Antoon Bosselaers and Bart Preneel.
- SHA1 (Secure Hash Algorithm 1) 160-bit hash function by NSA.
- SHA256 (Secure Hash Algorithm 2) 256-bit hash function by NSA.
- SHA384 (Secure Hash Algorithm 2) 384-bit hash function by NSA.
- SHA512 (Secure Hash Algorithm 2) 512-bit hash function by NSA.

There exist a few others as well, but they are not currently accepted by this
program. It is indeed quite surprising to see NSA's hash algorithms are being
used in several places despite the fact that, breaking security is what they
do. Despite the fact that these algorithms are quite complex, hash algorithms
can in principle be pretty simple like:

:: hash = Sum of all bytes in data

As can be seen, such a hash value is always 1 byte, no matter what the size of
the original data be. Thus by definition, this function is a hash function too!
It is simple functions like these, that are used to create hash tables
for accessing data by using any value as index of an array, in all programming
languages. Go ahead and create your own!
```

## usage

```batch
ohash [-a/--algo <algorithm>] [-s/--spaced] [<input file>]

:: [] -> optional argument
:: <> -> argument value
```

````batch
:: get md5 hash of a ohash.exe
ohash ohash.exe

:: get md5 hash of a ohash.exe (alternate)
cat ohash.exe | ohash

:: get sha256 hash of assignment.docx
ohash -a SHA256 assignment.docx

:: get ripemd160 hash of class notes.pdf
ohash --algo RIPEMD160 "class notes.pdf"

:: get spaced sha1 hash of star wars.mp4
cat "star wars.mp4" | ohash -a SHA1
```


## license

Do you have a Poké ball? That's enough!
