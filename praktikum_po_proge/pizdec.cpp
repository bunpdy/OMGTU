#include <iostream>
#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <Windows.h>
#include <conio.h>
#include <iostream>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <map>
#include <set>

int main(); 

struct Song {
	std::string artist;
	std::string track;
	std::string genre;
};

std::vector<Song> readSongsFromFile(const std::string& filename) {
	std::vector<Song> songs;
	std::ifstream file(filename);
	std::string line;
	while (std::getline(file, line)) {
		size_t pos1 = line.find('-');
		size_t pos2 = line.find('-', pos1 + 1);
		if (pos1 != std::string::npos && pos2 != std::string::npos) {
			songs.push_back({ line.substr(0, pos1), line.substr(pos1 + 1, pos2 - pos1 - 1), line.substr(pos2 + 1) });
		}
	}
	return songs;
}

void writeSongToFile(const Song& song) {
	std::ofstream file("songs.txt", std::ios_base::app);
	file << song.artist << "-" << song.track << "-" << song.genre << std::endl;
}

void displayGenres(const std::vector<Song>& songs) {
	std::set<std::string> genres;
	for (const auto& song : songs) {
		genres.insert(song.genre);
	}
	std::cout << "Доступные жанры:" << std::endl;
	for (const auto& genre : genres) {
		std::cout << "  - " << genre << std::endl;
	}
}

void displayArtistsByGenre(const std::vector<Song>& songs, const std::string& chosenGenre) {
	std::set<std::string> artists;
	for (const auto& song : songs) {
		if (song.genre == chosenGenre) {
			artists.insert(song.artist);
		}
	}
	std::cout << "Исполнители в жанре '" << chosenGenre << "':" << std::endl;
	for (const auto& artist : artists) {
		std::cout << "  - " << artist << std::endl;
	}
}


void addArtistAndTrack(std::vector<Song>& songs) {
	std::string artist, track, genre;
	std::cout << "Введите имя исполнителя: ";
	std::getline(std::cin, artist);
	std::cout << "Введите название трека: ";
	std::getline(std::cin, track);
	std::cout << "Введите жанр: ";
	std::getline(std::cin, genre);
	std::cout << "\nИсполнитель добавлен\n";
	Song newSong = { artist, track, genre };
	songs.push_back(newSong);
	writeSongToFile(newSong);
}

void addTrackToExistingArtist(std::vector<Song>& songs, const std::string& artist, const std::string& genre) {
	std::string track;
	std::cout << "Введите название трека: ";
	std::getline(std::cin, track);
	std::cout << "\nТрек добавлен\n";

	Song newSong = { artist, track, genre };
	songs.push_back(newSong);
	writeSongToFile(newSong);
}

void displayTracksByArtist(const std::vector<Song>& songs, const std::string& chosenArtist) {
	std::cout << "Треки исполнителя '" << chosenArtist << "':" << std::endl;
	for (const auto& song : songs) {
		if (song.artist == chosenArtist) {
			std::cout << "  - " << song.track << " (" << song.genre << ")" << std::endl;
		}
	}
}


int sprava() {
	setlocale(LC_ALL, ""); // Установка локали для поддержки русского языка
	std::vector<Song> songs = readSongsFromFile("songs.txt");

	displayGenres(songs);

	std::string chosenGenre;
	std::cout << "Выберите жанр: ";
	std::getline(std::cin, chosenGenre);

	std::cout << "Выберите действие:\n1. Добавить исполнителя\n2. Выбрать существующего исполнителя\n3. Просмотреть треки исполнителя\n";
	int action;
	std::cin >> action;
	std::cin.ignore(); // Очистка потока ввода

	if (action == 1) {
		addArtistAndTrack(songs);
	}
	else if (action == 2) {
		displayArtistsByGenre(songs, chosenGenre);
		std::string chosenArtist;
		std::cout << "Выберите исполнителя: ";
		std::getline(std::cin, chosenArtist);

		addTrackToExistingArtist(songs, chosenArtist, chosenGenre);
	}
	else if (action == 3) {
		std::string chosenArtist;
		std::cout << "Введите имя исполнителя для просмотра треков: ";
		std::getline(std::cin, chosenArtist);

		displayTracksByArtist(songs, chosenArtist);
	}
	else {
		std::cout << "Неверный выбор.\n";
	}

	return 0;
}


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
	printf("3) Календарь");
	SetConsoleCursorPosition(handle, { 35, 15 });
	printf("4) Графическая заставка");

	SetConsoleCursorPosition(handle, { 35, 16 });
	printf("5) Справочник");

	SetConsoleCursorPosition(handle, { 35, 17 });
	printf("6) Информация Об авторе");
	SetConsoleCursorPosition(handle, { 35, 18 });
	printf("0) Выход");
	SetConsoleCursorPosition(handle, { 35, 19 });
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
				std::cout << "Справ" << std::endl;
				break;
			case 5:
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
				sprava();
				break;
			case 5:
				system("cls");
				exit(0);
				break;
			}
		}
	}
}

