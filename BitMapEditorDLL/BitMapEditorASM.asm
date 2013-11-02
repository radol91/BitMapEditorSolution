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

ret	;wartoœæ zwracana jest przez akumulator!

Dodaj endp 

Negatyw PROC stdcall uses eax ebx ecx edx, tab :dword, ile :dword, cykle :dword

	RDTSC
	mov ECX, cykle				;pobranie adresu tablicy
	mov [ECX], EDX				;zapis starszej polowki licznika
	mov [ECX+4], EAX			;zapis mlodszej polowki licznika
	
	mov EAX, tab	;kopiuj adres 1 komorki
	add EAX, ile	;dodaj ilosc komorek
	sub EAX, 1		;przjedz do ost komorki
petla:
	mov BL, [EAX]	;pobierz komorke do rej
	mov CL, 255		;laduj FF do CL
	sub CL, BL		;neguj bajt w BL
	mov [EAX], CL	;zapisz zaneg bajt do pao
	cmp EAX, tab	;sprawdz koniec tablicy
	je koniec
	sub EAX, 1		;przesun sie w tablicy o 1 komorke do tylu
	jmp petla
koniec:	
	RDTSC						;dokonaj drugiego odczytu licznika cykli
	mov ECX, cykle	
	
	mov EBX, [ECX]				;odczytaj z pamieci poprzednie pomiary
	mov EBX, [ECX+4]
	
	sub EAX, [ECX+4]		;oblicz roznice
	sbb EDX, [ECX]		
	mov [ECX], EDX			;i zapisz rezultat do kolejnych dwoch pol tablicy
	mov [ECX+4], EAX

    ret 

Negatyw ENDP

end 