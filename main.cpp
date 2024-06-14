#include <iostream>
#include <windows.h>
#include <string>
#include <sstream>

int main() {

    WinMain(NULL, NULL, NULL, NULL);
    return 0;
}


// Function declarations
LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
void UpdateAudioSignal(HWND hwnd);

// Entry point
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {
    const char CLASS_NAME[] = "AudioSignalWindowClass";

    WNDCLASS wc = {};

    wc.lpfnWndProc = WindowProc;
    wc.hInstance = hInstance;
    wc.lpszClassName = CLASS_NAME;

    RegisterClass(&wc);

    HWND hwnd = CreateWindowEx(
        0,
        CLASS_NAME,
        "Audio Signal Display",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,
        NULL,
        NULL,
        hInstance,
        NULL
    );

    if (hwnd == NULL) {
        return 0;
    }

    ShowWindow(hwnd, nCmdShow);

    // Set a timer to update the audio signal every 1000 ms (1 second)
    SetTimer(hwnd, 1, 1000, NULL);

    MSG msg = {};
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return 0;
}

// Window procedure function
LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
    case WM_TIMER:
        UpdateAudioSignal(hwnd);
        return 0;
    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hwnd, &ps);

        // Retrieve the audio signal value from the window's user data
        int audioSignalValue = GetWindowLong(hwnd, NULL);

        // Convert the audio signal value to a string
        std::stringstream ss;
        ss << "Audio Signal Value: " << audioSignalValue;
        std::string text = ss.str();

        // Display the text
        TextOut(hdc, 10, 10, text.c_str(), text.length());

        EndPaint(hwnd, &ps);
    }
    return 0;
    }
    return DefWindowProc(hwnd, uMsg, wParam, lParam);
}

// Dummy function to simulate updating the audio signal
void UpdateAudioSignal(HWND hwnd) {
    // Here, you would get the actual audio signal value
    // For the sake of this example, we'll use a random value
    int audioSignalValue = rand() % 100;

    // Store the audio signal value in the window's user data
    SetWindowLong(hwnd, NULL, audioSignalValue);

    // Invalidate the window to trigger a repaint
    InvalidateRect(hwnd, NULL, TRUE);
}
