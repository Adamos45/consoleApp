#include <iostream>
#include <ctime>
#include <vector>

int main()
{
    std::cout << "c++\n";
    auto l = new std::vector<unsigned long long>();

    auto startTime = time(NULL);
    for (auto i = 1ULL; i < 100000; i++)
        for (auto j = 1ULL; j < 100000; j++)
        {
            auto z = i * j;
            l->push_back(z);
            if (z % 1000000000 == 0) {
                delete l;
                l = new std::vector<unsigned long long>();
            }
        }
    auto stopTime = time(NULL);
    delete l;

    std::cout << startTime << std::endl;
    std::cout << stopTime << std::endl;
    std::cout << stopTime - startTime << std::endl;
}