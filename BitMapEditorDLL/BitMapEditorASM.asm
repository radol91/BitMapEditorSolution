.686 
.387
.model flat, stdcall 
.xmm
.data
.code

Dodaj proc uses ebx a:DWORD, b:DWORD
mov eax,a
mov ebx,b
add eax, ebx

ret	;warto�� zwracana jest przez akumulator!

Dodaj endp 

end 