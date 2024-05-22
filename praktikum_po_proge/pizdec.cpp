#include <iostream>
#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <Windows.h>
#include <conio.h>


int main();

void SetColor(int text, int background) {
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

void setColor(int color) { // Перенесена функция setColor за пределы main
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
}

int graphic_splash() 
{ // графическая заставка
	int Return;
	std::cout << "Нажмите любую клавишу для запуска графической анимации." << std::endl;
	_getch(); // Ожидание нажатия клавиши

	srand(static_cast<unsigned int>(time(nullptr))); // Инициализация генератора случайных чисел

	CONSOLE_SCREEN_BUFFER_INFO csbi;
	GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), &csbi);
	const int width = csbi.srWindow.Right - csbi.srWindow.Left + 1;
	const int height = csbi.srWindow.Bottom - csbi.srWindow.Top + 1;

	while (true) {
		for (int i = 0; i < 50; ++i) {
			int x = rand() % width;
			int y = rand() % height;
			int radius = rand() % 10 + 5; // Радиус от 5 до 14
			int color = rand() % 15 + 1; // Случайный цвет

			setColor(color);
			for (int j = 0; j < 360; ++j) {
				double angle = j * 3.14159 / 180;
				int circleX = static_cast<int>(x + radius * cos(angle));
				int circleY = static_cast<int>(y + radius * sin(angle));
				if (circleX >= 0 && circleX < width && circleY >= 0 && circleY < height) {
					COORD coord = { static_cast<SHORT>(circleX), static_cast<SHORT>(circleY) };
					SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
					std::cout << "*";
				}
			}
		}

		Sleep(100); // Задержка для анимации
	}
back:
	printf("1) Главное меню\n2) Повтор\n3) Выход\n");
	scanf_s("%d", &Return);
	switch (Return) {
	case 1: main(); break;
	case 2: graphic_splash(); break;
	case 3: system("cls"); return 0; break;
	default: printf("Такого варианта нет!\n"); goto back;
	}
}
float Min(float F[], int n, float* max) { // минимум максимум
	float min = F[1];
	*max = F[1];
	for (int i = 0; i < n; i++) {
		if (min > F[i]) min = F[i];
		if (*max < F[i]) *max = F[i];
	}
	return min;
}

void Max(float arr[], int size, float* maxVal)
{// максимальный элемент массива
	*maxVal = arr[0];
	for (int i = 1; i < size; i++) {
		if (arr[i] > *maxVal) {
			*maxVal = arr[i];
		}
	}

}


int Chart() { // График
	float y1, y2, dx;
	int a = -1, b = 5, n = 15;
	float F1[15], F2[15], X[15];
	int Return, x0 = 950, y0 = 480;
	WORD nSize; TCHAR str[100];
	system("cls");
	HWND hWnd = FindWindowA("ConsoleWindowClass", NULL);
	HDC hdc = GetDC(hWnd);
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	HPEN penPurple = CreatePen(PS_SOLID, 1, RGB(249, 37, 168)); // фиолетовая кисть
	HPEN penGreen = CreatePen(PS_SOLID, 1, RGB(41, 255, 123)); // зеленый кисть
	SelectObject(hdc, GetStockObject(WHITE_PEN));
	MoveToEx(hdc, 0, y0 / 2, NULL); // рисование оси X
	LineTo(hdc, x0, y0 / 2);
	MoveToEx(hdc, x0 / 2, 0, NULL); // рисование оси Y
	LineTo(hdc, x0 / 2, y0);
	nSize = wsprintf(str, L"y(x) = 4*e^-|x| - 1");
	TextOut(hdc, x0 / 2 + x0 / 30 * X[3] + 10, y0 / 2 - x0 / 30 * F1[2] - 20, str, nSize);
	nSize = wsprintf(str, L"y(x) = cos(x)");
	TextOut(hdc, x0 / 2 + x0 / 30 * X[14], y0 / 2 - x0 / 30 * F2[14] - 20, str, nSize);
	nSize = wsprintf(str, L"x");
	TextOut(hdc, x0 - 5, y0 / 2 + 5, str, nSize);
	nSize = wsprintf(str, L"y");
	TextOut(hdc, x0 / 2 + 5, 5, str, nSize);
	for (int i = 0; i < n - 1; i++)
	{
		SelectObject(hdc, penPurple);
		MoveToEx(hdc, x0 / 2 + x0 / 30 * X[i], y0 / 2 - x0 / 30 * F1[i], NULL); // рисование F1
		LineTo(hdc, x0 / 2 + x0 / 30 * X[i + 1], y0 / 2 - x0 / 30 * F1[i + 1]);
		SelectObject(hdc, penGreen);
		MoveToEx(hdc, x0 / 2 + x0 / 30 * X[i], y0 / 2 - x0 / 30 * F2[i], NULL); // рисование F2
		LineTo(hdc, x0 / 2 + x0 / 30 * X[i + 1], y0 / 2 - x0 / 30 * F2[i + 1]);
	}
	while (_getch() != 13);
	return 0;
}

int author() {// Об авторе
	int Return;
	system("cls");
	printf("ОмГТУ\nФИО: Немчинов Никита Дмитриевич\nФакультет: ФИТиКС\nГруппа: ИВТ-232\n\n");
back:
	printf("1) Главное меню\n2) Выход\n");
	scanf_s("%d", &Return);
	switch (Return) {
	case 1: main(); break;
	case 2: system("cls"); return 0; break;
	default: printf("Такого варианта нет!\n"); goto back;
	}
}

void printMenu()
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(handle, { 43, 10 });
	printf("Главное меню\n");
	SetConsoleCursorPosition(handle, { 35, 14 });
	printf("4) Календарь");
	SetConsoleCursorPosition(handle, { 35, 15 });
	printf("5) Графическая заставка");
	SetConsoleCursorPosition(handle, { 35, 16 });
	printf("6) Информация Об авторе");
	SetConsoleCursorPosition(handle, { 35, 17 });
	printf("0) Выход");
	SetConsoleCursorPosition(handle, { 35, 18 });
}

void print_week(int[], int);

int calender()
{
	std::cout << "\n";

	int week1[]{ 0, 1, 0, 2, -1, 3, 3, 4, 5, -1, 3, 6, 2, -1, 6, -1, 7, 7, 3, -1, 8, 8, 8 };
	int week2[]{ 5, 2, 2, -1, 6, -1, 5, 3, 9, 9, 9, -1, 9, 10, 10, -1, 7, 6, 2, -1, 7, 2 };

	int week3[]{ 6, 3, 2, 2, -1, 12, 13, 3, -1, 5, 5, -1, 5, 4, 11, -1, 2, 2 };
	int week4[]{ 6, 11, 2, -1, 2, 12, 3, 2, -1, 1, -1, 12, 11, 6, -1, 3, 4 };

	while (true)
	{
		int term;
		int week;
		int subject;
		int hours = 0;

		std::cout << "Выбери семестр (1/2):";
		std::cin >> term;
		std::cout << "Выбери неделю (1 до 18):";
		std::cin >> week;
		std::cout << "Выбери предмет за который надо вывести часы за ранее выбранный семестр\n";
		std::cout << "0-опо, 1-курчас, 2-ин яз, 3-прог, 4-физ-ра, \n 5-опд, 6-мат, 7-иг, 8-орг, 9-физ, 10-цг, 11-эбвт, 12-аиловс, 13-прд:";
		std::cin >> subject;

		if (term == 1)
		{
			int size1 = sizeof(week1) / sizeof(week1[0]);
			int size2 = sizeof(week2) / sizeof(week2[0]);

			for (int i = 0; i < size1; i++)
			{
				if (subject == week1[i])
				{
					hours++;
				}
			}

			for (int j = 0; j < size2; j++)
			{
				if (subject == week2[j])
				{
					hours++;
				}
			}

			int res{ hours * 9 };

			int ost{ week % 2 };
			if (ost == 1)
			{
				print_week(week1, size1);
			}
			else
			{
				print_week(week2, size2);
			}

			std::cout << "Количество часов за выбранный предмет за семестр: " << res;
		}
		else
		{
			int size3 = sizeof(week3) / sizeof(week1[0]);
			int size4 = sizeof(week4) / sizeof(week2[0]);

			for (int i = 0; i < size3; i++)
			{
				if (subject == week3[i])
				{
					hours++;
				}
			}

			for (int j = 0; j < size4; j++)
			{
				if (subject == week4[j])
				{
					hours++;
				}
			}

			int res{ hours * 9 };

			int ost{ week % 2 };
			if (ost == 1)
			{
				print_week(week3, size3);
			}
			else
			{
				print_week(week4, size4);
			}

			std::cout << "Количество часов за выбранный предмет за семестр: " << res;

		}
		std::cout << "\n\n";

		int exxit = 1;
		std::cout << "Введите 0 для выхода или 1 для продолжения:";
		std::cin >> exxit;
		if (exxit == 0) 
		{
			break;
		}

	}

	return 0;
}


void print_week(int mass[], int sizze)
{
	std::cout << "@ПОНЕДЕЛЬНИК :" << "\n";
	int count = 0;
	for (int i{ 0 }; i < sizze; i++)
	{
		switch (mass[i])
		{
		case 0:
			std::cout << "открытое программное обеспечение" << "\n";
			break;
		case 1:
			std::cout << "кур час" << "\n";
			break;
		case 2:
			std::cout << "ин яз" << "\n";
			break;
		case 3:
			std::cout << "программирование" << "\n";
			break;
		case 4:
			std::cout << "физ-ра" << "\n";
			break;
		case 5:
			std::cout << "основы проф деятельности" << "\n";
			break;
		case 6:
			std::cout << "математика" << "\n";
			break;
		case 7:
			std::cout << "инженерная графика" << "\n";
			break;
		case 8:
			std::cout << "орг" << "\n";
			break;
		case 9:
			std::cout << "физика" << "\n";
			break;
		case 10:
			std::cout << "цифр грамотность" << "\n";
			break;
		case 11:
			std::cout << "элементарная база вычислительной техники " << "\n";
			break;
		case 12:
			std::cout << "арифмитические и логические основы вычислительных систем" << "\n";
			break;
		case 13:
			std::cout << "практика речевой деятельности" << "\n";
			break;
		default:
			count++;
			switch (count)
			{
			case 1:
				std::cout << "@ВТОРНИК :" << "\n";
				break;
			case 2:
				std::cout << "@СРЕДА :" << "\n";
				break;
			case 3:
				std::cout << "@ЧЕТВЕРГ :" << "\n";
				break;
			case 4:
				std::cout << "@ПЯТНИЦА :" << "\n";
				break;
			case 5:
				std::cout << "@СУББОТА :" << "\n";
				break;
			}
			break;
		}
	}
}


int main()
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	setlocale(0, ".1251");
	int choice = 1;
	int maxChoice = 5;

	while (true) {
		system("cls");
		SetConsoleCursorPosition(handle, { 40, 5 });
		std::cout << "Выберите действие:" << std::endl;

		for (int i = 1; i <= maxChoice; ++i) {
			SetConsoleCursorPosition(handle, { 40, (short)(5 + i) });
			if (i == choice) {
				std::cout << "-> ";
			}
			else {
				std::cout << "   ";
			}

			switch (i) {
			case 1:
				std::cout << "Календарь" << std::endl;
				break;
			case 2:
				std::cout << "Сведения об авторе" << std::endl;
				break;
			case 3:
				std::cout << "Графическая заставка" << std::endl;
				break;
			case 4:
				std::cout << "Выход" << std::endl;
				break;
			}
		}

		char key = _getch();

		if (key == -32) {
			key = _getch();
			switch (key) {
			case 72: // Up arrow
				choice = (choice - 1) > 0 ? choice - 1 : maxChoice;
				break;
			case 80: // Down arrow
				choice = (choice + 1) <= maxChoice ? choice + 1 : 1;
				break;
			}
		}
		else if (key == 13) { // Enter key
			switch (choice) {
			case 1:
				calender();
				break;
			case 2:
				author();
				break;
			case 3:
				graphic_splash();
				break;
			case 4:
				system("cls");
				exit(0);
				break;
			}
		}
	}
}
