.387
.model flat, stdcall 
.xmm
.data
.code

Dodaj proc uses ebx a:DWORD, b:DWORD
mov eax,a
mov ebx,b
add eax, ebx

ret	;wartoœæ zwracana jest przez akumulator!
Dodaj endp 

GreyASM PROC bitmap : dword, bWidth : dword, bHeight : dword
	pushad
	mov esi, bitmap
	mov eax, bWidth
	mov ebx, bHeight
	mul ebx
	mov ebx, 3				
	mul ebx					; EAX <- rozmiar obrazka w bajtach
	mov ecx, eax			; ECX <- rozmiar obrazka w bajtach
	add ecx, esi			; ECX <- adres zakonczenia procedury

	assume esi:ptr byte
	_loop:
			xor eax, eax	; Zerowanie rejestru
			xor ebx, ebx	; Zerowanie rejestru
			xor edx, edx	; Zerowanie rejestru
			mov al, [esi]	; AL <- skladowa R
			mov bl, [esi+1] ; BL <- skladowa G
			add eax, ebx	; EAX <- R+B
			mov bl, [esi+2]	; BL <- skladowa B
			add eax, ebx	; EAX <- R+B+G
			mov ebx, 3		; EBX <- 3 (dzielnik)
			div ebx			; AL <- R+B+G/3
			mov [esi], al	; NowaR <- AL
			mov [esi+1], al ; NowaG <- AL
			mov [esi+2], al ; NowaB <- AL

			add esi, 3
			cmp ecx, esi
			ja _loop
	endloop:
	popad
	ret
GreyASM ENDP

InverseASM PROC bitmap : dword, bWidth : dword, bHeight : dword
	pushad
	mov esi, bitmap
	mov eax, bWidth
	mov ebx, bHeight
	mul ebx
	mov ebx, 3
	mul ebx					; EAX <- rozmiar obrazka w bajtach
	mov ecx, eax			; ECX <- rozmiar obrazka w bajtach
	add ecx, esi			; ECX <- adres zakonczenia procedury
	
	assume esi:ptr byte
	_loop:
		mov al, 0FFh
		mov bl, [esi]		; pobranie wartosci skladowej do rejestru B
		xor al,bl			; operacja xorowania dzieki ktorej uzyskujemy wartosc odwrotna
		mov [esi],al		; zapisanie wartosci akumulatora pod adres
		add esi, 1			; przesuniecie sie o jedna skladowa (jeden adres).
		cmp ecx, esi
		ja _loop

	endloop:
	popad
	ret
InverseASM ENDP

SharpASM PROC bitmap : dword, result : dword, bWidth : dword, bHeight : dword
	pushad
	mov esi, bitmap
	mov edi, result
	mov eax, bWidth
	mov ebx, bHeight
	mul ebx
	mov ebx, 3
	mul ebx					; EBX <- rozmiar obrazka w bajtach
	mov edx, eax			; EDX <- rozmiar obrazka w bajtach
	mov ecx, eax
	add ecx, esi			; Adres ostatniego bajtu;
	
	mov eax, bWidth			; EAX <- szerokosc wiersza
	mov ebx, 3				
	mul ebx					; EAX <- szerkosc wiersza * 3
	mov edx, eax			; EDX <- szerkosc wiersza w bajtach

	sub ecx, edx			; Offset linia
	sub ecx, 3				; ECX <- adres zakonczenia procedury czyli ecx - offset_pixel - offset_line - linia 2 od gory i jeden piksel od konca	
	add esi, edx			; Przesuwamy sie na druga linie, pierwsz¹ omijamy poniewaz maska wystawalaby pod obrazem
	add edi, edx			; Przesuwamy sie na druga linie

	xor ebx, ebx

	assume esi:ptr byte 
	assume edi:ptr byte  
	_loop:
		push edx			; chowamy szerokosc lini na stos
		xor eax, eax
		mov al, [esi]		; aktualnie obrabiana skladowa
		mov ebx, 9			; razy 9			
		mul ebx				; EAX <- wartosc od ktorej bedziemy odejmowac kolejne skladowe ktore sa dookola
		pop edx
		
		mov bl, [esi+3]		; odejmowanie kolejnych skladowych dooko³a od AX
		sub ax, bx
		mov bl, [esi+edx+3]
		sub ax, bx
		mov bl, [esi+edx]
		sub ax, bx
		mov bl, [esi+edx-3] 
		sub ax, bx  
		mov bl, [esi-3] 
		sub ax, bx  
		push esi			; aktualna skladowa na stos
		sub esi, edx
		mov bl, [esi-3] 
		sub ax, bx 
		mov bl, [esi] 
		sub ax, bx 
		mov bl, [esi+3] 
		sub ax, bx 
		pop esi				; ze stosu adres aktualnej skladowej

		mov bx, ax

		cmp bh, 0h
		je write

		cmp bx, 0FFh
		jg write_255

		cmp bx, 0h
		jng write_zero

		assume esi:ptr byte 

	next:		
		add edi, 1					
		add esi, 1					; licz kolejna skladowa
		cmp ecx, esi				; sprawdz czy koniec
		ja _loop

	endloop:
	popad
	ret

	write: 
		mov [edi],bl			; jezeli jest z przedzialu 0,255 wstaw wartosc do tablicy wynikowej
		jmp next
	
	write_255: 
		mov [edi],0FFh			; jezeli ax jest wieksze od 255 ustaw 255
		jmp next

	write_zero: 
		mov [edi],0h			; jezeli ax jest mniejsze od 0 to ustaw 0
		jmp next

SharpASM ENDP
end 