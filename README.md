# Prompt Optimizer

Windows desktop application for analyzing and optimizing AI prompts using cloud APIs.

## Features
- Local prompt analysis (clarity, specificity, completeness scores)
- AI-powered optimization using Groq (primary) or Google AI (fallback)
- Secure local storage of API keys
- Professional Windows Forms UI
- No installation required (portable .exe)

## Requirements
- Windows 10 Pro or higher, 64-bit
- Internet connection (for API calls)
- Groq API key (free): https://console.groq.com
- Google AI API key (free): https://aistudio.google.com

## Installation
1. Download PromptOptimizer.exe
2. Place anywhere on your computer
3. Double-click to run

## Usage
1. Launch PromptOptimizer.exe
2. Click ⚙️ API Settings button
3. Enter your Groq API key (from https://console.groq.com)
4. Enter your Google AI API key (optional, used as fallback)
5. Click Save
6. Enter your prompt in "Original Prompt" field
7. Click "Analyze Prompt" to see metrics
8. Click "Generate Optimization" for AI improvements
9. Copy optimized prompt to clipboard

## API Configuration

### Getting Groq API Key
1. Visit https://console.groq.com
2. Sign up or log in
3. Go to API Keys section
4. Create new API key
5. Copy and paste into app settings

### Getting Google AI API Key
1. Visit https://aistudio.google.com
2. Sign in with Google account
3. Click "Get API Key"
4. Copy and paste into app settings

## System Requirements
- CPU: Intel i3 or equivalent or better
- RAM: 4 GB minimum (8 GB recommended)
- Disk: 50 MB available
- Network: Required (for Groq/Google APIs)

## Troubleshooting

### "Invalid API Key"
- Double-check key copy-paste
- Ensure no extra spaces
- Verify key format:
  * Groq keys start with "gsk_"
  * Google keys start with "AIza"

### "No Response from API"
- Check internet connection
- Verify API keys are valid
- Try the fallback provider (automatically attempted)
- Check https://status.groq.com or https://status.google.com for API outages

### "API Keys Not Saving"
- Ensure AppData folder is writable
- Check: C:\Users\[YourName]\AppData\Roaming\PromptOptimizer\
- Clear folder and try again

## Costs
- **Groq**: 14.400 tokens/day FREE
- **Google AI**: 32.000 tokens/day FREE
- ~200 tokens per optimization
- = 240+ free optimizations per day!

## Privacy
- API keys stored locally only (not cloud-backed)
- No prompts logged or stored on servers
- All computation happens on your machine
- Only API calls to Groq/Google APIs use internet

## License
MIT License

## Support
Check API documentation:
- Groq: https://console.groq.com/docs
- Google AI: https://ai.google.dev/docs
