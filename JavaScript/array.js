// -- Standard functions

// Array.concat() - Join two arrays
if( typeof Array.prototype.concat==='undefined' ) {
 Array.prototype.concat = function( a ) {
  for( var i = 0, b = this.copy(); i<a.length; i++ ) {
   b[b.length] = a[i];
  }
  return b;
  };
}

// Array.copy() - Copy an array
if( typeof Array.prototype.copy==='undefined' ) {
 Array.prototype.copy = function() {
  var a = [], i = this.length;
  while( i-- ) {
   a[i] = typeof this[i].copy!=='undefined' ? this[i].copy() : this[i];
  }
  return a;
 };
}

// Array.pop() - Remove and return the last element of an array
if( typeof Array.prototype.pop==='undefined' ) {
 Array.prototype.pop = function() {
  var b = this[this.length-1];
  this.length--;
  return b;
 };
}

// Array.push() - Add an element to the end of an array, return the new length
if( typeof Array.prototype.push==='undefined' ) {
 Array.prototype.push = function() {
  for( var i = 0, b = this.length, a = arguments, l = a.length; i<l; i++ ) {
   this[b+i] = a[i];
  }
  return this.length;
 };
}

// Array.shift() - Remove and return the first element
if( typeof Array.prototype.shift==='undefined' ) {
 Array.prototype.shift = function() {
  for( var i = 0, b = this[0], l = this.length-1; i<l; i++ ) {
   this[i] = this[i+1];
  }
  this.length--;
  return b;
 };
}

// Array.slice() - Copy and return several elements
if( typeof Array.prototype.slice==='undefined' ) {
 Array.prototype.slice = function( a, c ) {
  var i, l = this.length, r = [];
  if( !c ) { c = l; }
  if( c<0 ) { c = l + c; }
  if( a<0 ) { a = l - a; }
  if( c<a ) { i = a; a = c; c = i; }
  for( i = 0; i < c - a; i++ ) { r[i] = this[a+i]; }
  return r;
 };
}

// Array.splice() - Remove or replace several elements and return any deleted elements
if( typeof Array.prototype.splice==='undefined' ) {
 Array.prototype.splice = function( a, c ) {
  var i = 0, e = arguments, d = this.copy(), f = a, l = this.length;
  if( !c ) { c = l - a; }
  for( i; i < e.length - 2; i++ ) { this[a + i] = e[i + 2]; }
  for( a; a < l - c; a++ ) { this[a + e.length - 2] = d[a - c]; }
  this.length -= c - e.length + 2;
  return d.slice( f, f + c );
 };
}

// Array.unshift() - Add an element to the beginning of an array
if( typeof Array.prototype.unshift==='undefined' ) {
 Array.prototype.unshift = function() {
  this.reverse();
  var a = arguments, i = a.length;
  while(i--) { this.push(a[i]); }
  this.reverse();
  return this.length;
 };
}

// -- 4umi additional functions

// Array.forEach( function ) - Apply a function to each element
Array.prototype.forEach = function( f ) {
 var i = this.length, j, l = this.length;
 for( i=0; i<l; i++ ) { if( ( j = this[i] ) ) { f( j ); } }
};

// Array.indexOf( value, begin, strict ) - Return index of the first element that matches value
Array.prototype.indexOf = function( v, b, s ) {
 for( var i = +b || 0, l = this.length; i < l; i++ ) {
  if( this[i]===v || s && this[i]==v ) { return i; }
 }
 return -1;
};

// Array.insert( index, value ) - Insert value at index, without overwriting existing keys
Array.prototype.insert = function( i, v ) {
 if( i>=0 ) {
  var a = this.slice(), b = a.splice( i );
  a[i] = v;
  return a.concat( b );
 }
};

// Array.lastIndexOf( value, begin, strict ) - Return index of the last element that matches value
Array.prototype.lastIndexOf = function( v, b, s ) {
 b = +b || 0;
 var i = this.length; while(i-->b) {
  if( this[i]===v || s && this[i]==v ) { return i; }
 }
 return -1;
};

// Array.random( range ) - Return a random element, optionally up to or from range
Array.prototype.random = function( r ) {
 var i = 0, l = this.length;
 if( !r ) { r = this.length; }
 else if( r > 0 ) { r = r % l; }
 else { i = r; r = l + r % l; }
 return this[ Math.floor( r * Math.random() - i ) ];
};

// Array.shuffle( deep ) - Randomly interchange elements
Array.prototype.shuffle = function( b ) {
 var i = this.length, j, t;
 while( i ) {
  j = Math.floor( ( i-- ) * Math.random() );
  t = b && typeof this[i].shuffle!=='undefined' ? this[i].shuffle() : this[i];
  this[i] = this[j];
  this[j] = t;
 }
 return this;
};

// Array.unique( strict ) - Remove duplicate values
Array.prototype.unique = function( b ) {
 var a = [], i, l = this.length;
 for( i=0; i<l; i++ ) {
  if( a.indexOf( this[i], 0, b ) < 0 ) { a.push( this[i] ); }
 }
 return a;
};

// Array.walk() - Change each value according to a callback function
Array.prototype.walk = function( f ) {
 var a = [], i = this.length;
 while(i--) { a.push( f( this[i] ) ); }
 return a.reverse();
};